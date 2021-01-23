        string GetResultString(string data)
        {
            string[] arrData = data.Split(',').ToArray();
            List<int> lstData = new List<int>();
            foreach (string item in arrData)
            {
                lstData.Add(Convert.ToInt16(item));
            }
            lstData.Sort();
            string finalStr = string.Empty;
            if (lstData.Count > 0)
            {
                int start = lstData[0];
                int end = start;
                finalStr = string.Empty;
                for (int index = 1; index < lstData.Count; index++)
                {
                    if (end + 1 == lstData[index])
                    {
                        end = lstData[index];
                    }
                    else
                    {
                        finalStr += appendResult(start, end);
                        start = -1;
                    }
                    if (start == -1)
                    {
                        start = lstData[index];
                        end = lstData[index];
                    }
                }
                finalStr += appendResult(start, end);
            }
            finalStr = finalStr.Trim(',');
            return finalStr;
        }
        string appendResult(int start,int end)
        {
            string res = string.Empty;
            if (end - start > 1)
            {
                res += start + "-" + end.ToString() + ",";
                start = -1;
            }
            else
            {
                while (start <= end)
                {
                    res += start.ToString() + ",";
                    start++;
                }
            }
            return res;
        }
