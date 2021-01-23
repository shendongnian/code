	using System;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using System.Runtime.Remoting;
	using System.Runtime.Remoting.Messaging;
	using System.Runtime.Remoting.Proxies;
	using System.Windows.Forms;
	
	namespace Net4ToNet2Adapter
	{
	    [ComVisible(true)]
	    [Guid("E36BBF07-591E-4959-97AE-D439CBA392FB")]
	    public interface IMyClassAdapter
	    {
	    	void DoNet4Action( [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(ProxyMarshaler))] Control c);
	    }
	    
	    [ComVisible(true)]
	    [Guid("9F973534-E089-4C22-A481-54403B97DED9")]
	    public interface IProxyProvider
	    {
	    	Type Type{get;}
	    	object Instance{get;}
	    	object Invoke(string method, Type[] signature, object[] args);
	    }
	    
	    public class ProxyMarshaler : ICustomMarshaler
	    {
	    	private static readonly ProxyMarshaler instance = new ProxyMarshaler();
	    	
	    	public static ICustomMarshaler GetInstance(string cookie)
	    	{
	    		return instance;
	    	}
	    	
			public IntPtr MarshalManagedToNative(object ManagedObj)
			{
				return Marshal.GetIUnknownForObject(new ProxyProvider(ManagedObj));
			}
	    	
			public object MarshalNativeToManaged(IntPtr pNativeData)
			{
				IProxyProvider prov = (IProxyProvider)Marshal.GetObjectForIUnknown(pNativeData);
				return new ComProxy(prov).GetTransparentProxy();
			}
	    	
			public void CleanUpNativeData(IntPtr pNativeData)
			{
				Marshal.Release(pNativeData);
			}
	    	
			public void CleanUpManagedData(object ManagedObj)
			{
				ComProxy proxy = (ComProxy)RemotingServices.GetRealProxy(ManagedObj);
				proxy.Dispose();
			}
	    	
			public int GetNativeDataSize()
			{
				return -1;
			}
			
	    
		    private class ProxyProvider : IProxyProvider
		    {
		    	public Type Type{get; private set;}
		    	public object Instance{get; private set;}
		    	
		    	public ProxyProvider(object instance)
		    	{
		    		Instance = instance;
		    		Type = instance.GetType();
		    	}
		    	
		    	public object Invoke(string method, Type[] signature, object[] args)
		    	{
		    		MethodInfo mi = Type.GetMethod(method, signature);
		    		if(mi == null || mi.IsStatic) throw new NotSupportedException();
		    		DeproxyArgs(args);
		    		object ret = mi.Invoke(Instance, args);
		    		ProxyArgs(args);
		    		return ProxyValue(ret);
		    	}
		    	
		    	public static bool IsProxyable(Type t)
		    	{
		    		return t.IsInterface || typeof(MarshalByRefObject).IsAssignableFrom(t) || t == typeof(object);
		    	}
		    	
		    	public static void DeproxyArgs(object[] args)
		    	{
		    		for(int i = 0; i < args.Length; i++)
		    		{
		    			args[i] = DeproxyValue(args[i]);
		    		}
		    	}
		    	
				public static void ProxyArgs(object[] args)
				{
					for(int i = 0; i < args.Length; i++)
					{
						args[i] = ProxyValue(args[i]);
					}
				}
				
				public static object DeproxyValue(object val)
				{
					var pp = val as IProxyProvider;
					if(pp != null)
					{
						if(val is ProxyProvider) return pp.Instance;
						else return ComProxy.GetProxy(pp);
					}
					return val;
				}
				
				public static object ProxyValue(object val)
				{
					ComProxy proxy = ComProxy.GetProxy(val);
					if(proxy != null)
					{
						return proxy.Provider;
					}else if(val != null && ProxyProvider.IsProxyable(val.GetType()))
					{
						return new ProxyProvider(val);
					}
					return val;
				}
		    }
		    
		    private sealed class ComProxy : RealProxy, IDisposable
		    {
		    	public IProxyProvider Provider{get; private set;}
		    	
		    	public ComProxy(IProxyProvider provider) : base(provider.Type == typeof(object) ? typeof(MarshalByRefObject) : provider.Type)
		    	{
		    		Provider = provider;
		    	}
		    	
		    	public static object GetProxy(IProxyProvider provider)
		    	{
		    		return new ComProxy(provider).GetTransparentProxy();
		    	}
		    	
		    	public static ComProxy GetProxy(object proxy)
		    	{
		    		if(proxy == null) return null;
		    		return RemotingServices.GetRealProxy(proxy) as ComProxy;
		    	}
		    	
				public override IMessage Invoke(IMessage msg)
				{
					IMethodCallMessage msgCall = msg as IMethodCallMessage;
					if(msgCall != null)
					{
						object[] args = msgCall.Args;
						try{
							ProxyProvider.ProxyArgs(args);
							object ret = Provider.Invoke(msgCall.MethodName, (Type[])msgCall.MethodSignature, args);
							ProxyProvider.DeproxyArgs(args);
							Console.WriteLine(msgCall.MethodName);
							ret = ProxyProvider.DeproxyValue(ret);
							return new ReturnMessage(ret, args, args.Length, msgCall.LogicalCallContext, msgCall);
						}catch(TargetInvocationException e)
						{
							return new ReturnMessage(e.InnerException, msgCall);
						}catch(Exception e)
						{
							return new ReturnMessage(e, msgCall);
						}
					}
					return null;
				}
				
				~ComProxy()
				{
					Dispose(false);
				}
				
				private void Dispose(bool disposing)
				{
					if(disposing)
					{
						Marshal.FinalReleaseComObject(Provider);
					}
				}
				
				public void Dispose()
				{
					Dispose(true);
					GC.SuppressFinalize(this);
				}
		    }
	    }
	}
