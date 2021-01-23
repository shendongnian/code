First, your XML is invalid. You want `` after `<?xml>` like:
    <?xml version=""1.0"" encoding=""utf-8""?>
    <code>
        <result is_array=""true"">
            <item>
                <candidate_offer_id>175</candidate_offer_id><contact_person>Ranjeet Singh</contact_person><offer_status>8</offer_status>
            </item>
            <item><candidate_offer_id>176</candidate_offer_id><contact_person>Ranjeet Singh</contact_person><offer_status>8</offer_status>
            </item>
        </result>
    </code>
I'd make a class to contain each item like
    static void Main(string[] args)
    {
        var str = XElement.Parse(xml);
        var items = str.Descendants("item");
        List<Item> Items = new List<Item>();
        foreach (var item in items)
        {
            Items.Add(new Item
            {
                OfferID = Convert.ToInt32(item.Element("candidate_offer_id").Value),
                Person = item.Element("contact_person").Value,
                Status = Convert.ToInt32(item.Element("offer_status").Value)
            });
        }
    }
    class Item
    {
        public int OfferID { get; set; }
        public string Person { get; set; }
        public int Status { get; set; }
    }
