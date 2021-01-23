        IEnumerable<Data> GetMatches(List<Data> dataList, string number)
        {
            var matches = new List<Data>();
            int maxLength = 5;
            while (maxLength > 0)
            {
                if (dataList.Any(p => p.Designation.StartsWith(number.Substring(0, maxLength))))
                {
                    matches.AddRange(dataList.Where(p => p.Designation.StartsWith(number.Substring(0, maxLength))));
                    break;
                }
                maxLength--;
            } 
            return matches;
        }
