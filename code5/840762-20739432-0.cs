    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
        static void Main(string[] args)
        {
            var handle = IntPtr.Zero;
            do
            {
                handle = FindWindowEx(IntPtr.Zero, handle, "#32770", null);
                if (handle != IntPtr.Zero )
                    Console.WriteLine("Found handle: {0:X}", handle.ToInt64());
            } while (handle != IntPtr.Zero);
            Console.ReadLine();
        }
    }
