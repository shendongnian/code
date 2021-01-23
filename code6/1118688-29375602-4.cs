    public class PartnerDataDictionary
    {
        public PartnerDataDictionary()
        {
            this.ParameterDictionary = new Dictionary<string, string>();
        }
        string _error;
        public string error { get { return _error; } set { _error = value; } }
        string _message;
        public string message { get { return _message; } set { _message = value; } }
        [System.Web.Script.Serialization.ScriptIgnore]
        public Dictionary<string, string> ParameterDictionary { get; set; }
        public List<Dictionary<string, string>> parameters
        {
            get
            {
                List<Dictionary<string, string>> dictList = new List<Dictionary<string, string>>();
                foreach (KeyValuePair<string, string> pair in ParameterDictionary)
                {
                    Dictionary<string, string> subDict = new Dictionary<string,string>(1);
                    subDict[pair.Key] = pair.Value;
                    dictList.Add(subDict);
                }
                return dictList;
            }
            set
            {
                if (value == null)
                {
                    ParameterDictionary = new Dictionary<string, string>();
                    return;
                }
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (Dictionary<string, string> entry in value)
                    foreach (KeyValuePair<string, string> pair in entry)
                        dict.Add(pair.Key, pair.Value);
                ParameterDictionary = dict;
            }
        }
        public string GetParameter(string key)
        {
            string value;
            if (ParameterDictionary.TryGetValue(key, out value))
                return value;
            return null;
        }
        public void SetParameter(string key, string value)
        {
            ParameterDictionary[key] = value;
        }
        // Add other properties as needed, marking them as `ScriptIgnore`:
        [System.Web.Script.Serialization.ScriptIgnore]
        public string Programs
        {
            get { return GetParameter("Programs"); }
            set { SetParameter("Programs", value); }
        }
    }
