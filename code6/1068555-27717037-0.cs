            string message1 = "Google.Apis.Requests.RequestError.Entity already exists. "
                              +"[409]. Errors [. Message[Entity already exists.] Location [ - ] Reason [duplicate] Domain [global] .]";
            string message2 = "Google.Apis.Requests.RequestError.Domain user limit reached. "
                              +"[412]. Errors [. Message[Domain user limit reached.] Location [If-Match - header] Reason[limitExceeded] Domain[global] .]";
            string pattern = @"Message\[((\w+\s){2,}(\w+\s?)*)\.\]";
            Regex regex = new Regex(pattern);
            Match m = regex.Match(message1); //or regex.Match(message2)
            if (m.Success)
            {
                Group g = m.Groups[1]; //m.Groups[0] will Match 'Message[.....]'
                CaptureCollection cc = g.Captures;
                for (int i = 0; i < cc.Count; i++)
                {
                    Capture c = cc[i];
                    Console.WriteLine("Message: {0}", c);
                }
            }
            Console.ReadLine();
