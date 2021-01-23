            List<String> MessageList = new List<string>();
            MessageList.Add("HelloHelloHello");
            MessageList.Add("Hello1Hello1Hello1");
            MessageList.Add("Hello1Hello1Hello1");
            MessageList.Add("Hello1Hello1Hello1");
            MessageList.Add("HelloHelloHello");
            MessageList.Add("HelloHelloHello");
            List<String> output =  MessageList.Select<string, string>(s => s == "HelloHelloHello" ? "Hello Hello Hello" : s).ToList();
            foreach (String str in output)
            {
                Console.WriteLine(str);
            }
