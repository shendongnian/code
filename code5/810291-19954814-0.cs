     string numberString = "2-6,8,10-15,20-23";
               
     List<int> cNumberString = getValidString(numberString);
    
     List<int> getValidString(string str)
            {
                List<int> lstNumber = new List<int>();
    
                string[] cNumberArray = str.Split(',');
    
                for (int k = 0; k < cNumberArray.Length; k++)
                {
                    string tmpDigit = cNumberArray[k];
                    if (tmpDigit.Contains("-"))
                    {
                        int start = int.Parse(tmpDigit.Split('-')[0].ToString());
                        int end = int.Parse(tmpDigit.Split('-')[1]);
    
                        for (int j = start; j <= end; j++)
                        {
                            if (!lstNumber.Contains(j))
                                lstNumber.Add(j);
                        }
                    }
                    else
                    {
                        lstNumber.Add(int.Parse(tmpDigit));
                    }
                }
    
                return lstNumber;
            }
