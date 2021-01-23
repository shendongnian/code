    class Program
    {
        private static void Main(string[] args)
        {
            var a = "asample";
    
            unsafe
            {
                fixed (char* str_char = a)
                {
                    var count = wcslen(str_char);
                }
            }
        }
        
        private static unsafe int wcslen(char* ptr)
        {
          // impl
        }
    }
