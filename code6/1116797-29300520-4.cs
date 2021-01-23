    class MyClass
    {
        public delegate IntPtr MessageHandlerDelegate(IntPtr ptr);
        [DllImport("mydll.dll")]
        public static extern void register_message_handler(MessageHandlerDelegate del);
        public MessageHandlerDelegate Del { get; set; }
        public void Register()
        {
            // Make a copy of the delegate
            Del = Handler;
            register_message_handler(Del);            
        }
        public IntPtr Handler(IntPtr ptr)
        {
            // I don't know what ptr is
            Console.WriteLine("Handled");
            return IntPtr.Zero; // Return something sensible
        }
    }
