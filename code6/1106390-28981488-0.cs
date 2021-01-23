    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                Console.WriteLine("we should see both Debug and Trace .WriteLine\n");
                System.Diagnostics.Trace.WriteLine("This is From Debug.WriteLine\n");
                System.Diagnostics.Debug.WriteLine("This is From Trace.WriteLine\n");
                System.Diagnostics.Trace.WriteLine("This is From Debug.WriteLine\n");
                System.Diagnostics.Debug.WriteLine("This is From Trace.WriteLine\n");
                Console.WriteLine("watched 2 Dbg and 2 Trace WriteLine in windbg\n");
                System.Diagnostics.Trace.WriteLine("This is From Debug.WriteLine\n");
                System.Diagnostics.Debug.WriteLine("This is From Trace.WriteLine\n");
                System.Diagnostics.Trace.WriteLine("This is From Debug.WriteLine\n");
                System.Diagnostics.Debug.WriteLine("This is From Trace.WriteLine\n");
            }
        }
    }
