        public void Something()
        {
            // Using Dictionary
            var dict = new Dictionary<string, string>();
            dict.Add("tag1", "tag1,datestamp,0.01");
            dict.Add("tag2", "tag2,datestamp,0.02");
            // out -> "tag2,datestamp,0.02"            
            System.Diagnostics.Debug.WriteLine(dict["tag2"]);    
            // Using two separate lists
            var tags = new List<string> { "tag1", "tag2" };
            var infos = new List<string> { "tag1,datestamp,0.01", "tag2,datestamp,0.02" };
            // out ->  tag1,datestamp,0.01 & tag2,datestamp,0.02
            tags.ForEach(tag =>
                System.Diagnostics.Debug.WriteLine(
                    infos.First(info => info.StartsWith(tag)))); 
        }
