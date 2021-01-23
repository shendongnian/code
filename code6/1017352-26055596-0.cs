    using (SPSite site = new SPSite("http://c4968397007/sites/anupamsworkspace/"))
    {
        using (SPWeb web = site.OpenWeb())
        {
            var list = web.Lists["Check2"];
            var item = list.Items[0];
            foreach (var field in list.Fields)
            {
                Console.WriteLine("Key: {0} Value: {1}", field.StaticName, item[field.StaticName])
            }
        }
    }
