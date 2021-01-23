    I recently had a similar requirement where decimal/float values were needed in a 10-digit format with 4 decimal places.  (For example:  "000123.4560").
    
    Here's how I did it.  (There's probably a simpler method, but it's been working great so far...):
    int k = 0;
    bool DecFound = false;
    string s1=TodaysResults[1, i].ToString();
    string IntegerDigits = "";
    string DecimalDigits = "";
    for (int j = 0; j < s1.Length; j++)
    	{
    		if (s1.Substring(j, 1) == ".")
                    	{
                            	k = j;
                                    DecFound = true;
    			}
    			if (DecFound == false)
                                {
                                    IntegerDigits += s1.Substring(j, 1);
                                }
                                else
                                {
                                    DecimalDigits += s1.Substring(j, 1);
                                }
                            }
                            switch (IntegerDigits.Length)
                            {
                                case 0:
                                    IntegerDigits = "000000";
                                    break;
                                case 1:
                                    IntegerDigits = "00000" + IntegerDigits;
                                    break;
                                case 2:
                                    IntegerDigits = "0000" + IntegerDigits;
                                    break;
                                case 3:
                                    IntegerDigits = "000" + IntegerDigits;
                                    break;
                                case 4:
                                    IntegerDigits = "00" + IntegerDigits;
                                    break;
                                case 5:
                                    IntegerDigits = "0" + IntegerDigits;
                                    break;
                                default:
                                    break;
                            }
                            switch (DecimalDigits.Length)
                            {
                                case 0:
                                    DecimalDigits = DecimalDigits + ".0000";
                                    break;
                                case 1:
                                    DecimalDigits = DecimalDigits + "0000";
                                    break;
                                case 2:
                                    DecimalDigits = DecimalDigits + "000";
                                    break;
                                case 3:
                                    DecimalDigits = DecimalDigits + "00";
                                    break;
                                case 4:
                                    DecimalDigits = DecimalDigits + "0";
                                    break;
                                default:
                                    break;
                            }
    	}
