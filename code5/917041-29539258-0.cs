        public static void temp22db()
        {
            Dictionary<string, Dictionary<string, string>> dictionary22 = new Dictionary<string, Dictionary<string, string>>();
            try
            {
                Dictionary<string, string> did = new Dictionary<string, string>();
                did.Add("F186 1", "test1");
                did.Add("F186 2", "test2");
                dictionary22.Add("F186", did);
                did.Add("EDA0 1", "test3");
                did.Add("EDA0 2", "test4");
                dictionary22.Add("EDA0", did);
                string test;
                did.TryGetValue("EDA0 1", out test);
                Helper.logInWindow("This works " + test);
            }
            catch (Exception e)
            {
                Helper.logInWindow("SDDBTemp: " + e.Message);
            }
            ecuDictionary2.TryAdd("1638", dictionary22);
        }
        public static string getDIDInterpretation()
        {
            string outStr = "";
            Dictionary<string, Dictionary<string, string>> tmpDictionary;
            ecuDictionary2.TryGetValue("1638", out tmpDictionary);
            if (tmpDictionary != null)
            {
                Dictionary<string, string> tmpDictionaryDid;
                tmpDictionary.TryGetValue("EDA0", out tmpDictionaryDid);
                if (tmpDictionaryDid != null)
                {
                    tmpDictionaryDid.TryGetValue("EDA0 1", out outStr);
                }
            }
            Helper.logInWindow("Why U no work? " + outStr);
            return outStr;
        }
