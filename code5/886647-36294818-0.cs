            WebClient MyClient = new WebClient();
            MyClient.Headers.Add("Content-Type", "application/json");
            MyClient.Headers.Add("User-Agent", "DIMS /0.1 +http://www.xxx.dk");
            WebHeaderCollection myWebHeaderCollection = MyClient.Headers;
            for (int i = 0; i < myWebHeaderCollection.Count; i++)
            {
                Console.WriteLine("\t" + myWebHeaderCollection.GetKey(i) + " = " + myWebHeaderCollection.Get(i));
            }
