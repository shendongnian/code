        using System;
        using System.Runtime.Remoting.Activation;
        using System.Runtime.Remoting.Contexts;
        using System.Runtime.Remoting.Messaging;
        using System.Threading;
        using System.Threading.Tasks;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var c1 = new Class1();
                    var t = c1.Method1();
                    Func<Task> f = c1.Method1;
                    f.BeginInvoke(null, null);
                    Console.ReadKey();
                }
            }
    
            [MyContext]
            public class Class1 : ContextBoundObject
            {
                private string one = "1";
                public async Task Method1()
                {
                    Console.WriteLine(one);
                    await Task.Delay(50);
                    Console.WriteLine(one);
                }
            }
            sealed class MyContextAttribute : ContextAttribute
            {
                public MyContextAttribute()
                    : base("My")
                {
                }
                public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
                {
                    if (ctorMsg == null)
                        throw new ArgumentNullException("ctorMsg");
                    ctorMsg.ContextProperties.Add(new ContributeInstallContextSynchronizationContextMessageSink());
                }
                public override bool IsContextOK(Context ctx, IConstructionCallMessage ctorMsg)
                {
                    return false;
                }
            }
            sealed class ContributeInstallContextSynchronizationContextMessageSink : IContextProperty, IContributeServerContextSink
            {
                public ContributeInstallContextSynchronizationContextMessageSink()
                {
                }
                public IMessageSink GetServerContextSink(IMessageSink nextSink)
                {
                    return new InstallContextSynchronizationContextMessageSink(nextSink);
                }
                public string Name { get { return "ContributeInstallContextSynchronizationContextMessageSink"; } }
                public bool IsNewContextOK(Context ctx)
                {
                    return true;
                }
                public void Freeze(Context ctx)
                {
                }
            }
            sealed class InstallContextSynchronizationContextMessageSink : IMessageSink
            {
                readonly IMessageSink m_NextSink;
                public InstallContextSynchronizationContextMessageSink(IMessageSink nextSink)
                {
                    m_NextSink = nextSink;
                }
                public IMessageSink NextSink
                {
                    get { return m_NextSink; }
                }
                public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
                {
                    var contextSyncContext = new ContextSynchronizationContext(SynchronizationContext.Current);
                    var syncContextReplacer = new SynchronizationContextReplacer(contextSyncContext);
                    DelegateMessageSink.SyncProcessMessageDelegate replySyncDelegate = (n, m) => SyncProcessMessageDelegateForAsyncReply(n, m, syncContextReplacer);
                    var newReplySink = new DelegateMessageSink(replySink, replySyncDelegate, null);
                    return m_NextSink.AsyncProcessMessage(msg, newReplySink);
                }
                public IMessage SyncProcessMessage(IMessage msg)
                {
                    var contextSyncContext = new ContextSynchronizationContext(SynchronizationContext.Current);
                    using (new SynchronizationContextReplacer(contextSyncContext))
                    {
                        var ret = m_NextSink.SyncProcessMessage(msg);
                        return ret;
                    }
                }
                private IMessage SyncProcessMessageDelegateForAsyncReply(IMessageSink nextSink, IMessage msg, SynchronizationContextReplacer syncContextReplacer)
                {
                    syncContextReplacer.Dispose();
                    return nextSink.SyncProcessMessage(msg);
                }
                private void PreChecks()
                {
                    if (SynchronizationContext.Current != null)
                        return;
                    if (TaskScheduler.Current != TaskScheduler.Default)
                        throw new InvalidOperationException("InstallContextSynchronizationContextMessageSink does not support calling methods with SynchronizationContext.Current as null while Taskscheduler.Current is not TaskScheduler.Default");
                }
            }
            sealed class SynchronizationContextReplacer : IDisposable
            {
                SynchronizationContext m_original;
                SynchronizationContext m_new;
                public SynchronizationContextReplacer(SynchronizationContext syncContext)
                {
                    m_original = SynchronizationContext.Current;
                    m_new = syncContext;
                    SynchronizationContext.SetSynchronizationContext(m_new);
                }
                public void Dispose()
                {
                    // We don't expect the SynchronizationContext to be changed during the lifetime of the SynchronizationContextReplacer
                    if (SynchronizationContext.Current != m_new)
                        throw new InvalidOperationException("SynchronizationContext was changed unexpectedly.");
                    SynchronizationContext.SetSynchronizationContext(m_original);
                }
            }
    
            sealed class ContextSynchronizationContext : PassThroughSynchronizationConext
            {
                readonly Context m_context;
                private ContextSynchronizationContext(SynchronizationContext passThroughSyncContext, Context ctx)
                    : base(passThroughSyncContext)
                {
                    if (ctx == null)
                        throw new ArgumentNullException("ctx");
                    m_context = ctx;
                }
                public ContextSynchronizationContext(SynchronizationContext passThroughSyncContext)
                    : this(passThroughSyncContext, Thread.CurrentContext)
                {
                }
                protected override SynchronizationContext CreateCopy(SynchronizationContext copiedPassThroughSyncContext)
                {
                    return new ContextSynchronizationContext(copiedPassThroughSyncContext, m_context);
                }
                protected override void CreateSendOrPostCallback(SendOrPostCallback d, object state)
                {
                    CrossContextDelegate ccd = () => d(state);
                    m_context.DoCallBack(ccd);
                }
            }
            abstract class PassThroughSynchronizationConext : SynchronizationContext
            {
                readonly SynchronizationContext m_passThroughSyncContext;
                protected PassThroughSynchronizationConext(SynchronizationContext passThroughSyncContext)
                    : base()
                {
                    m_passThroughSyncContext = passThroughSyncContext;
                }
                protected abstract void CreateSendOrPostCallback(SendOrPostCallback d, object state);
                protected abstract SynchronizationContext CreateCopy(SynchronizationContext copiedPassThroughSyncContext);
                public sealed override void Post(SendOrPostCallback d, object state)
                {
                    var d2 = CreateSendOrPostCallback(d);
                    if (m_passThroughSyncContext != null)
                        m_passThroughSyncContext.Post(d2, state);
                    else
                        base.Post(d2, state);
                }
                public sealed override void Send(SendOrPostCallback d, object state)
                {
                    var d2 = CreateSendOrPostCallback(d);
                    if (m_passThroughSyncContext != null)
                        m_passThroughSyncContext.Send(d2, state);
                    else
                        base.Send(d2, state);
                }
                public sealed override SynchronizationContext CreateCopy()
                {
                    var copiedSyncCtx = m_passThroughSyncContext != null ? m_passThroughSyncContext.CreateCopy() : null;
                    return CreateCopy(copiedSyncCtx);
                }
                public sealed override void OperationCompleted()
                {
                    if (m_passThroughSyncContext != null)
                        m_passThroughSyncContext.OperationCompleted();
                    else
                        base.OperationCompleted();
                }
                public sealed override void OperationStarted()
                {
                    if (m_passThroughSyncContext != null)
                        m_passThroughSyncContext.OperationStarted();
                    else
                        base.OperationStarted();
                }
                public sealed override int Wait(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout)
                {
                    return m_passThroughSyncContext != null ?
                        m_passThroughSyncContext.Wait(waitHandles, waitAll, millisecondsTimeout) :
                        base.Wait(waitHandles, waitAll, millisecondsTimeout);
                }
                private SendOrPostCallback CreateSendOrPostCallback(SendOrPostCallback d)
                {
                    SendOrPostCallback sopc = s => CreateSendOrPostCallback(d, s);
                    return sopc;
                }
            }
            sealed class DelegateMessageSink : IMessageSink
            {
                public delegate IMessage SyncProcessMessageDelegate(IMessageSink nextSink, IMessage msg);
                public delegate IMessageCtrl AsyncProcessMessageDelegate(IMessageSink nextSink, IMessage msg, IMessageSink replySink);
                readonly IMessageSink m_NextSink;
                readonly SyncProcessMessageDelegate m_syncProcessMessageDelegate;
                readonly AsyncProcessMessageDelegate m_asyncProcessMessageDelegate;
                public DelegateMessageSink(IMessageSink nextSink, SyncProcessMessageDelegate syncProcessMessageDelegate, AsyncProcessMessageDelegate asyncProcessMessageDelegate)
                {
                    m_NextSink = nextSink;
                    m_syncProcessMessageDelegate = syncProcessMessageDelegate;
                    m_asyncProcessMessageDelegate = asyncProcessMessageDelegate;
                }
                public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
                {
                    return (m_asyncProcessMessageDelegate != null) ?
                        m_asyncProcessMessageDelegate(m_NextSink, msg, replySink) :
                        m_NextSink.AsyncProcessMessage(msg, replySink);
                }
                public IMessageSink NextSink
                {
                    get { return m_NextSink; }
                }
                public IMessage SyncProcessMessage(IMessage msg)
                {
                    return (m_syncProcessMessageDelegate != null) ?
                        m_syncProcessMessageDelegate(m_NextSink, msg) :
                        m_NextSink.SyncProcessMessage(msg);
                }
            }
        }
