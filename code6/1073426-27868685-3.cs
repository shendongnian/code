        public bool readAppConfig(string appConfigPath)
        {
            Recs=new Dictionary<string, List<Rec>>()
            {
                {"Headers",    new List<Rec>()},
                {"Ignores",    new List<Rec>()},
                {"Exceptions", new List<Rec>()}
            };
            foreach(string sectionName in Recs.Keys)
            {
                var recSection=ConfigurationManager.GetSection(sectionName) as NameValueCollection;
                foreach(string key in recSection.AllKeys)
                {
                    Rec r=new Rec(key);
                    r.Push(recSection[key].Split(';', ' '));
                    Recs[sectionName].Add(r);
                }
            }
            return true;
        }
