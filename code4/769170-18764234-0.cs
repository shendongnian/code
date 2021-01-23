           string str1 = "3,4,5,6,8,10,11,12";
            string[] strArr = str1.Split(',');
            List<string> strFinal = new List<string>();
            int[] myInts = Array.ConvertAll(strArr, s => int.Parse(s));
            int arrLn = myInts.Length;
            Array.Sort(myInts);
            int intPrevVal = myInts[0];
            int intPrevDiff = myInts[0];
            int seriesCount = 1;
            strFinal.Add(Convert.ToString(myInts[0]));
            for (int j = 1; j < arrLn; j++)
            {
                int intCurr = myInts[j];
                if (intCurr - intPrevVal == 1)
                {
                    seriesCount++;
                }
                else
                {
                    if (seriesCount >= 3)
                    {
                        strFinal[strFinal.Count - 1] = strFinal[strFinal.Count - 1] + "-" + intPrevVal;
                        seriesCount = 1;
                    }
                    else if (seriesCount == 2)
                    {
                        strFinal.Add(Convert.ToString(myInts[j - 1]));
                        seriesCount = 1;
                        //strFinal.Add(Convert.ToString(myInts[j]));
                    }
                    strFinal.Add(Convert.ToString(myInts[j]));
                }
                intPrevVal = intCurr;
            }
            if (seriesCount >= 3)
            {
                strFinal[strFinal.Count - 1] = strFinal[strFinal.Count - 1] + "-" + myInts[arrLn - 1];
            }
            else if (seriesCount == 2)
            {                
                strFinal.Add(Convert.ToString(myInts[arrLn - 1]));
            }
            string FinalAns = string.Join(",", strFinal.ToArray());
            Response.Write(FinalAns);
