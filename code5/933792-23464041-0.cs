        private BidInfo BidInfoParser(XDocument doc)
        {
            BidInfo info = null;
            //get the first record in the result set
            XContainer c1 = (XContainer)(doc);
            XContainer c2 = (XContainer)(c1.FirstNode);
            //loop through fields
            foreach (XNode node in c2.Nodes())
            {
                XElement el = (XElement)node;
                string key = el.Name.LocalName;
                string value = el.Value;
                //little hack to only set BidInfo if there are some values
                if(info == null)
                    info = new BidInfo();
                if (key.Equals("Active", StringComparison.InvariantCultureIgnoreCase))
                    info.Active = Convert.ToBoolean(value);
                else if (key.Equals("BidID", StringComparison.InvariantCultureIgnoreCase))
                    info.BidID = Convert.ToInt32(value);
                else if (key.Equals("Bits", StringComparison.InvariantCultureIgnoreCase))
                    info.Bits = Convert.ToInt32(value);
                else if (key.Equals("BookingID", StringComparison.InvariantCultureIgnoreCase))
                    info.BookingID = Convert.ToInt32(value);
                else if (key.Equals("Country", StringComparison.InvariantCultureIgnoreCase))
                    info.Country = value;
                else if (key.Equals("MaxPrice", StringComparison.InvariantCultureIgnoreCase))
                    info.MaxPrice = Convert.ToDecimal(value);
                else if (key.Equals("MinECU", StringComparison.InvariantCultureIgnoreCase))
                    info.MinECU = Convert.ToInt32(value);
                else if (key.Equals("MinRAM", StringComparison.InvariantCultureIgnoreCase))
                    info.MinRAM = Convert.ToInt32(value);
                else if (key.Equals("Deleted", StringComparison.InvariantCultureIgnoreCase))
                    info.Deleted = Convert.ToBoolean(value);
                else if (key.Equals("IncLowBW", StringComparison.InvariantCultureIgnoreCase))
                    info.IncludeLowBandwidth = Convert.ToBoolean(value);
                else if (key.Equals("scriptID", StringComparison.InvariantCultureIgnoreCase))
                    info.ScriptID = Convert.ToInt32(value);
                else if (key.Equals("userdata", StringComparison.InvariantCultureIgnoreCase))
                    info.UserData = value;
                else
                    throw new Exception("Unknown tag in XML:" + key + " = " + value);
            }
            return info;
        }
        /// <summary>
        /// Contains information about this bid.
        /// </summary>
        public class BidInfo
        {
            public int BidID { get; set; }
            public int BookingID { get; set; }
            public bool Active { get; set; }
            public decimal MaxPrice { get; set; }
            public int MinECU { get; set; }
            public int MinRAM { get; set; }
            public string Country { get; set; }
            public int Bits { get; set; }
            public bool Deleted { get; set; }
            public bool IncludeLowBandwidth { get; set; }
            public int ScriptID { get; set; }
            public string UserData { get; set; }
        }
