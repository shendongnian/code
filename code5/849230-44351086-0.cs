    using System;
    
    namespace RFAnnouncer
    {
        public static class ExtensionMethods
        {
            public static string GetEnclosureUri(this System.ServiceModel.Syndication.SyndicationItem item)
            {
                for (int i = 0; i < item.Links.Count; i++)
                {
                    if (item.Links[i].RelationshipType == "enclosure")
                    {
                        return item.Links[i].Uri.AbsoluteUri;
                    }
                }
                return "";
            }
        }
    }
