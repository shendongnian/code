    class testing
    {
        private Dictionary<string, string> dict = new Dictionary<string, string>();
        private Dictionary<string, string> _dict = new Dictionary<string, string>();
        private Dictionary<string, string> __dict = new Dictionary<string, string>();
        public testing() 
        {
            dict.Add("stringA", string.Empty);
            dict.Add("stringB", "123456");
            dict.Add("stringC", string.Empty);
            _dict.Add("stringA", string.Empty);
            _dict.Add("stringB", string.Empty);
            _dict.Add("stringC", string.Empty);
            __dict.Add("stringA", "654321");
            __dict.Add("stringB", "123456");
            __dict.Add("stringC", string.Empty);
            checkDict(dict, "dictionary1");
            checkDict(_dict, "dictionary2");
            checkDict(__dict, "dictionary3");
        }
        private void checkDict(Dictionary<string,string> myDict, string s)
        {
            try
            {
                var exam = dict.Where(x => !string.IsNullOrEmpty(x.Value)).ToDictionary(x => x.Key);
                foreach (var kvp in exam)
                {
                    Console.WriteLine(kvp.Value.Value);
                }
            }
            catch(Exception ex)
            {
                eh(ex);
            }
        }
        private void eh(Exception ex)
        {
            Console.WriteLine(ex.Message);
            if (ex.InnerException != null) eh(ex.InnerException);
        }
    }
