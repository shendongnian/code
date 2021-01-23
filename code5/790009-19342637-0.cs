           if (line.Trim().EndsWith(":"))
           {
               productList = new List<string>();
               freeDutyProduct.Add(line.Replace(":", ""),productList);
           }
           else
           {
               productList.Add(line.Trim());
           }
