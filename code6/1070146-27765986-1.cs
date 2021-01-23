    class Program
    {
        static void Main(string[] args)
        {
            List<string> result = new List<string>();
            string text = "Now im checking first ten chars from sentence and some random chars : asdasdasdasdasdasdasdasd";
            try
            {
                for (int i = 0; i < text.Length; i = i + 10)
                {
                    string res = text.Substring(i,10);
                    result.Add(res);
                    Console.WriteLine(res);
                }
            }
            catch (Exception)
            {
            }
        }
    }
