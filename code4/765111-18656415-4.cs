    string temp = s;
            string tempResult = "";
            bool found = false;
            do
            {
                    tempResult = "";
                    found = false;
                    if (s.Length < lenght) return s;
                    else
                    {
                        //Examine every word to cut everything into words
                        string[] tempList = temp.Split(' ');
                        foreach (string temp2 in tempList)
                        {
                            //Check every word length now,
                            if (temp2.Length > lenght)
                            {
                                tempResult = tempResult + " " + temp2.Substring(0, lenght - 3) + "- " + temp2.Substring(lenght -3);
                                found = true;
                            }
                            else
                                tempResult = tempResult + " " + temp2;
                        }
                        if (found) temp = tempResult;
                    }
                } while (found);
        
                return tempResult.TrimStart();
