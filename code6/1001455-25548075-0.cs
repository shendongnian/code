            SortedDictionary<UInt16, string> xTypes = new SortedDictionary<UInt16, string>();
            String[] rows = Regex.Split("23,TRUNK-1,Trunk-1,,[Barry_Boehm]", "\r\n");
            foreach (var i in rows)
            {
                String[] words = i.Split(new[] { ',' });
                UInt16 proNumber = Convert.ToUInt16(words[0]);
                string proName = words[1];
                xTypes.Add(proNumber, proName);
            }
