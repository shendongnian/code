    public static void Test()
            {
                Regex re = new Regex("^[a-zA-Z0-9][a-zA-Z0-9-]{1,61}[a-zA-Z0-9]\\.[a-zA-Z]{2,}$");
                var m=re.Match("test.com");
                Console.WriteLine(m.Groups[0].Value);
                m=   re.Match("more-messy-domain-0234-example.xx");
                Console.WriteLine(m.Groups[0].Value);
           }
