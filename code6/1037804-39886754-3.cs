    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.InteropServices;
    
    namespace GenericDelegates {
      static class DelegateCreator {
        public static readonly Func<Type[], Type> MakeNewCustomDelegate = (Func<Type[], Type>) Delegate.CreateDelegate(
          typeof(Func<Type[], Type>),
          typeof(Expression).Assembly.GetType("System.Linq.Expressions.Compiler.DelegateHelpers").GetMethod(
            "MakeNewCustomDelegate",
            BindingFlags.NonPublic | BindingFlags.Static
          )
        );
        public static Type NewDelegateType(Type ret, params Type[] parameters) {
          var offset = parameters.Length;
          Array.Resize(ref parameters, offset + 1);
          parameters[offset] = ret;
          return MakeNewCustomDelegate(parameters);
        }
      }
      static class Kernel {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string name);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr module, string name);
      }
      static class InvokeHelper {
        public static Delegate MakeDelegate(this IntPtr address, Type ret, params Type[] parameters) {
          return Marshal.GetDelegateForFunctionPointer(address, DelegateCreator.NewDelegateType(ret, parameters));
        }
      }
      class Program {
        static void Main(string[] args) {
          var kernel = Kernel.GetModuleHandle("kernel32.dll");
          var address = Kernel.GetProcAddress(kernel, "GetModuleHandleW");
          Console.WriteLine(@"
    Module base: 0x{0:X8}
    Entry point: 0x{1:X8}
    ", (int) kernel, (int) address);
          var invoke = address.MakeDelegate(typeof(IntPtr), typeof(string));
          Console.WriteLine(@"
    Untyped delegate: {0}
    Cast to Invoke: {1}
    ", invoke, invoke as Func<string, IntPtr> == null ? "Error" : "Valid"); // invoke as Func<string, IntPtr> = NULL
          Console.ReadKey();
        }
      }
    }
