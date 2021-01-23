        public static void Main()
        {
            HttpException ex = new HttpException ();
            string text = ex;
            Console.WriteLine(text);
            Console.ReadLine();
        }
        public class HttpException 
        {
            public string Text = "goofy";
            public static implicit operator string(HttpException ex)
            {
                return ex.Text;
            }
        }
