    public class UserContext
    {
        public string AccountNo { get; set; }
        public string AuthValue { get; set; }
        public Auth AuthObject { get; private set; }
        internal UserContext Deserialize()
        {
            // Serialize the object
            this.AuthObject = JsonConvert.DeserializeObject<Auth>(this.AuthValue);
            // Return this object for a simple single-line call.
            return this;
        }
    }
    // Single object
    UserContext conObj1 = new UserContext();
    conObj1 = JsonConvert.DeserializeObject<UserContext>(context).Deserialize();
    // Enumeration of object (given that this is supported in JsonConvert)
    IEnumerable<UserContext> conObjs = JsonConvert.DeserializeObject<IEnumerable<UserContext>(contexts).Select(c => c.Deserialize()).ToList();
