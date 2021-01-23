        private static void Main(string[] args)
        {
            var encodedString = System.IO.File.ReadAllText(@"D:\original.txt");
            var bytes = System.Convert.FromBase64String(encodedString);
            System.IO.File.WriteAllBytes("d:\\result.rar", bytes);
        }
