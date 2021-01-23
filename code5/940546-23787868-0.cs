    using Microsoft.SharePoint;
    namespace SOEventReceiver.ExternalTest
    {
        public class ExternalTest : SPItemEventReceiver
        {
            public override void ItemAdding(SPItemEventProperties properties)
            {
                string strid = (properties.AfterProperties["strid"] ?? string.Empty).ToString();
                if (!string.IsNullOrWhiteSpace(strid))
                {
                    properties.AfterProperties["external_id"] = strid + ";#" + strid;
                }
                base.ItemAdding(properties);
            }
            public override void ItemUpdating(SPItemEventProperties properties)
            {
                string strid = (properties.AfterProperties["strid"] ?? string.Empty).ToString();
                if (!string.Equals(strid, properties.ListItem["strid"] ?? string.Empty))
                {
                    properties.AfterProperties["external_id"] = strid + ";#" + strid;
                }
                base.ItemUpdating(properties);
            }
        }
    } 
