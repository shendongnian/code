    class Test
    {
        static void JustThrow(out int x)
        {
            throw new Exception();
        }
        static void Main()
        {
            int y = 10;
            try
            {
                JustThrow(out y);
            }
            catch
            {
                // Ignore
            }
            Console.WriteLine(y); // Still prints 10
        }
    }
