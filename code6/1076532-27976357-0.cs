            PropertySet psPropSetaaaa = new PropertySet(BasePropertySet.FirstClassProperties);
            NameResolutionCollection coll = service.ResolveName("glen", ResolveNameSearchLocation.DirectoryOnly, true, psPropSetaaaa);
            foreach (NameResolution nameRes in coll)
            {
                Console.WriteLine("Contact name: " + nameRes.Contact.DirectoryId);
            }
