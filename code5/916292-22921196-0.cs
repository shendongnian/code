    public async Task Post()
    {
        bool validJson = false;
        string originalData = await Request.Content.ReadAsStringAsync();
    
        try
        {
            JObject jo = JObject.Parse(originalData);
            validJson = true;
        }
        catch (JsonReaderException)
        {
        }
    
        string modifiedData = null;
        if (!validJson)
        {
            modifiedData = "{" + originalData + "}";
        }
        else
        {
            modifiedData = originalData;
        }
    
        AddressBook book = JsonConvert.DeserializeObject<AddressBook>(modifiedData);
    
        //TODO: do something with the book
    }
    public class AddressBook
    {
        [JsonProperty("randomJsonObjects")]
        public IEnumerable<ContactInfo> Contacts { get; set; }
    }
    
    public class ContactInfo
    {
        public string Email { get; set; }
        public long TimeStamp { get; set; }
        public string Id { get; set; }
    }
