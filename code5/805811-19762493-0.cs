     foreach (string COLUMNS in values)
                    {
                        STR.Append("'");
                        STR.Append(COLUMNS);
                        STR.Append("' , "); //here is mistake
                    }
                    //Removing the last COMMA( , ) 
                    string toTrim = STR.ToString();
                  string lol= toTrim.Substring(0, toTrim.Length - 1);
