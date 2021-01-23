            List<string> sampleList = new List<string>();
            sampleList.Add("1");
            sampleList.Add("2");
            sampleList.Add("3");
            sampleList.Add("4");
            sampleList.Add("5");
            // Will not work
            foreach (string item in sampleList)
            {
                sampleList.Remove(item);
            }
            
            // Will work
            foreach (string item in sampleList.ToList())
            {
                sampleList.Remove(item);
            }
