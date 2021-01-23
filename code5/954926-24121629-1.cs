        Data GetMatch(List<Data> dataList, string number)
        {
            var match = new Data();
            int maxLength = 5;
            while (maxLength > 0)
            {
                if (dataList.Any(p => p.Designation.StartsWith(number.Substring(0, maxLength))))
                {
                    match = dataList.FirstOrDefault(p => p.Designation.StartsWith(number.Substring(0, maxLength)));
                    break;
                }
                maxLength--;
            }
            return match;
        }
