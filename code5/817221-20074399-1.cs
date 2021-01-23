        static class M
        {
            public static void WriteTextToConsole(this string text,params string[] str)
            {
                if (str.Length > 0)
                {
                    //do something with extra string or strings
                    //you can make params Object[] but for this
                    //example i choose string[]
                    Console.WriteLine(text);
                    return;
                }
    
                Console.WriteLine(text);
            }
        }
