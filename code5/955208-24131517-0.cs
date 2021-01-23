                var myMainData = new Dictionary<int, List<Dictionary<string, string>>>();
                var myDataValue = new List<Dictionary<string, string>>();
                var values = new Dictionary<string, string>();
                //get the first key once
                int lastKeyId = Convert.ToInt32(dataSet.Tables["CountryData"].Rows[0]["Keyid"]);
                foreach (DataRow row in dataSet.Tables["CountryData"].Rows)
                {
                    int key = Convert.ToInt32(row["Keyid"]);
                    if (lastKeyId != key)
                    {
                        myMainData.Add(key, myDataValue);  //add this to the dictionary
                        myDataValue.Clear(); //clear previous list value
                        values.Clear(); //clear previous values
                    }
                    //add new values
                    values.Add(row["Data1"].ToString(), row["Data2"].ToString());
                    myDataValue.Add(values);
                    lastKeyId = key; //set the current key
                }
