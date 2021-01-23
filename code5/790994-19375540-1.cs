        private List<string> ConvertIntToString(Enum days, params int[]  daysIds)
        {
            List<string> stringList = new List<string>();
            foreach (var item in daysIds)
	        {
                stringList.Add(Enum.ToObject(days.GetType(), item).ToString());
	        }
            return stringList;
        }
