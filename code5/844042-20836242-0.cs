    public class CustomObject
    {
        public string ID { get; set; }
        public string Date { get; set; }
        public string Target { get; set; }
        public string ASO { get; set; }
        public string Below { get; set; }
    }
    public class CustomObjectMerger
    {
        public List<CustomObject> Merge()
        {
            List<CustomObject> list1 = new List<CustomObject>();
            List<CustomObject> list2 = new List<CustomObject>();
            List<CustomObject> result = new List<CustomObject>();
            list1.Add(new CustomObject { ID = "3", Date = "12/28/2013", Target = "1" });
            list1.Add(new CustomObject { ID = "4", Date = "12/30/2013", Target = "33" });
            list2.Add(new CustomObject { ID = "3", ASO = "100", Below = "50" });
            list2.Add(new CustomObject { ID = "4", ASO = "40", Below = "33" });
            foreach (CustomObject customObject1 in list1)
            {
                foreach (CustomObject customObject2 in list2)
                {
                    if (customObject1.ID == customObject2.ID)
                    {
                        result.Add(new CustomObject { ID = customObject1.ID, ASO = customObject2.ASO, Below = customObject2.Below, Target = customObject1.Target, Date = customObject1.Date });
                    }
                }
            }
            return result;
        }
    }
