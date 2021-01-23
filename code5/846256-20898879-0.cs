    static void Main()
        {
            int? num = null;
    
            // Is the HasValue property true? 
            if (num.HasValue)
            {
                System.Console.WriteLine("num = " + num.Value);
            }
            else
            {
                System.Console.WriteLine("num = Null");
            }
