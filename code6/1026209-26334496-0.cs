     protected void Page_Load(object sender, EventArgs e)
            {
                string message = "";
                string[] list = new string[] { "Bill cat had", "Bill had a cat", "Cat had Bill" };
                foreach (var item in list)
                {
                    string[] splitString = item.Trim().Split(' ');
                    int i = 0; bool IsValid = true;
                    int count = 0;
                    foreach (var sindividual in splitString)
                    {
                        int j = CheckMatched(sindividual);
                        if (j != 0)
                        {
                            if (j > i)
                            {
                                i = j;
                                count++;
                            }
                            else
                            {
                                IsValid = false;
                            }
                        }
                    }
    
    
                    if (count >= 3 && IsValid)
                    {
                        message += item + "   " + "yes it has t proper order \n";
                    }
                    else
                    {
                        message += item + "   " + "Doesnt have proper order \n";
                    }
                }
    
                lblMessage.Text = message;
    
    
            }
    
    
            int CheckMatched(string sStringtoCheck)
            {
                sStringtoCheck = sStringtoCheck.Trim().ToLower();
    
                if (sStringtoCheck.Contains("bill"))
                {
                    return 1;
                }
                else if (sStringtoCheck.Contains("had"))
                {
                    return 2;
                }
                else if (sStringtoCheck.Contains("cat"))
                {
                    return 3;
                }
                else return 0;
            }
