    using System;
    using System.Diagnostics;
    using System.Reflection;
    
    // The library that calls Trace, causing the messages you want to suppress.
    using NoisyLibrary;
    
    namespace TraceSuppress
    {
        /// <summary>
        /// Trace listener that ignores trace messages from a specific assembly.
        /// </summary>
        public class AssemblyFilteredListener : DefaultTraceListener
        {
            private Assembly assemblyToIgnore;
    
            public AssemblyFilteredListener(Assembly assemblyToIgnoreTracesFrom)
            {
                this.assemblyToIgnore = assemblyToIgnoreTracesFrom;
            }
    
            public bool TraceIsFromAssemblyToIgnore()
            {
                StackTrace traceCallStack = new StackTrace();
    
                StackFrame[] traceStackFrames = traceCallStack.GetFrames();
    
                // Look for the assembly to ignore in the call stack.
                //
                // This may be rather slow for very large call stacks. If you find that this is a bottleneck
                // there are optimizations available.
                foreach (StackFrame traceStackFrame in traceStackFrames)
                {
                    MethodBase callStackMethod = traceStackFrame.GetMethod();
    
                    bool methodIsFromAssemblyToIgnore = (callStackMethod.Module.Assembly == this.assemblyToIgnore);
    
                    if (methodIsFromAssemblyToIgnore)
                    {
                        return true;
                    }
    
                }
    
                // The assembly to ignore was not found in the call stack.
                return false;         
    
            }
    
            
            public override void WriteLine(string message)
            {
                if (!this.TraceIsFromAssemblyToIgnore())
                {
                    base.WriteLine(message);
                }
            }         
            
            public override void Write(string message)
            {
                if (!this.TraceIsFromAssemblyToIgnore())
                {
                    base.Write(message);
                }
            }
        }
    
        class Program
        {
            static void SetupListeners()
            {
                // Clear out the default trace listener
                Trace.Listeners.Clear();
    
                // Grab the asssembly of the library, using any class from the library.
                Assembly assemblyToIgnore = typeof(NoisyLibrary.LibraryClass).Assembly;
    
                // Create a TraceListener that will ignore trace messages from that library
                TraceListener thisApplicationOnlyListener = new AssemblyFilteredListener(assemblyToIgnore);
    
                Trace.Listeners.Add(thisApplicationOnlyListener);
    
                // Now the custom trace listener is the only listener in Trace.Listeners.
            }
    
            static void Main(string[] args)
            {
                SetupListeners();            
    
                // Testing
                //-------------------------------------------------------------------------
    
                // This still shows up in the output window in VS...
                Trace.WriteLine("This is a trace from the application, we want to see this.");
    
                // ...but the library function that calls trace no longer shows up.
                LibraryClass.MethodThatCallsTrace();
    
                // Now check the output window, the trace calls from that library will not be present.
    
            }
        }
    }
