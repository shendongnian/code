    static void Main(string[] args)
        {
            foreach (string file in Directory.GetFiles("MyPath"))
            {
                if (Path.GetExtension(file)=="youExtension")
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        //Your code
                    }
                }
            }
        }
