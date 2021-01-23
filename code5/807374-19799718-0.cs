        static void Main(string[] args)
        {
            
            MethodA();//called from line 26 on my code
            
            Console.ReadLine();
        }
        private static void MethodA()
        {
            var stacktrace = new StackTrace(true);//be sure to pass true to obtain line info
            for (int i = 0; i < stacktrace.FrameCount; i++)
            {
                var frame = stacktrace.GetFrame(i);
                Console.WriteLine("{0}, {1}, {2}, {3}", frame.GetFileLineNumber(), frame.GetMethod(), frame.GetFileName(), frame.GetFileColumnNumber());
           
            }
        }
