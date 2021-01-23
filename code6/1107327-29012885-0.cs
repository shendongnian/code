        public static IList<string> Parser(string srvString)
        {
            IList<string> list = new List<string>();
            while (!string.IsNullOrWhiteSpace(srvString))
            {
                string[] split = srvString.Split();
                string code = srvString.Split()[0];
                switch (code)
                {
                    case "2001":
                        int i = 13;
                        if (i >= split.Length)
                        {
                            // we are a the end of the server message
                            list.Add(srvString);
                            srvString = null;
                        }
                        else
                        {
                            string last = split[i - 1];
                            Match match = Regex.Match(last, "(2001|3001|6001)");
                            if (!match.Success) throw new Exception("Parsing error");
                            string msg = srvString.Substring(0, srvString.IndexOf(last, code.Length) + last.Length - 4);
                            list.Add(msg);
                            srvString = srvString.Substring(msg.Length);
                        }
                        break;
                    case "3001":
                        i = 8;
                        if (i >= split.Length)
                        {
                            // we are a the end of the server message
                            list.Add(srvString);
                            srvString = null;
                        }
                        else
                        {
                            string last = split[i - 1];
                            Match match = Regex.Match(last, "(2001|3001|6001)");
                            if (!match.Success) throw new Exception("Parsing error");
                            string msg = srvString.Substring(0, srvString.IndexOf(last, code.Length) + last.Length - 4);
                            list.Add(msg);
                            srvString = srvString.Substring(msg.Length);
                        }
                        break;
                    case "6001":
                        i = 9;
                        if (i >= split.Length)
                        {
                            // we are a the end of the server message
                            list.Add(srvString);
                            srvString = null;
                        }
                        else
                        {
                            string last = split[i - 1];
                            Match match = Regex.Match(last, "(2001|3001|6001)");
                            if (!match.Success) throw new Exception("Parsing error");
                            string msg = srvString.Substring(0, srvString.IndexOf(last, code.Length) + last.Length - 4);
                            list.Add(msg);
                            srvString = srvString.Substring(msg.Length);
                        }
                        break;
                    default:
                        throw new Exception("Unkown message code: " + code);
                }   // switch
                
            }   // while...
            // return the list
            return list;
        }
