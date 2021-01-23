        private List<string> ConvertIntToString(params int[]  daysIds)
        {
            List<string> stringList = new List<string>();
    
            foreach (var item in daysIds)
            {
                stringList.Add(Enum.ToObject(typeof(Days), item).ToString());
            }
    
            return stringList;
        }
