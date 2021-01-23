    int i;
                int k = 0;
                for (i = 0; i < firstarray.Count; i++)
                {
                    secondarray[k] = firstarray[k].ToString();
                    {
                        if (firstarray[k] == "25")
                        {
                            secondarray[k] = "15, 9";
                        }
                        else if (firstarray[k] == "22")
                        {
                            secondarray[k] = "15, 7";
                        }
    					k++;
                    }
                }
                    return secondarray;
    
                }
        
