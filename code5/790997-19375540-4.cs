            private List<Enum> ConvertIntToString(params int[] daysIds)
            {
                List<Enum> EnumList = new List<Enum>();
                foreach (var item in daysIds)
    	        {
                    EnumList.Add((Days)item);
    	        }
                return EnumList;
            }
