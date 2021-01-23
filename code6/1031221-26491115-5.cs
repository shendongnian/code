    public static void checkChangedPerm(Object sender, EventArgs e)
    {
        CheckBox c = sender as CheckBox;
            
        if (c.Name != null && c.Name != "")
        {
            StreamReader reader;
            int count = c.Name.Count();
            string trimmed = c.Name.ToString();
            string outPut = trimmed.Remove(count - 4);            
            using (reader = new StreamReader(dataFolder + PermFile))
            {
                //Here you check the state of checkbox
                if(c.Checked == false) //add the name in file
                {
                    trimmed = reader.ReadToEnd(); //re-use the trimmed string. Don't need a new one
                    if (!trimmed.Contains(outPut))
                    {
                        trimmed += outPut;
                        permLine_ = trimmed;
                    }
                }
                else //remove name
                {
                    permLine_ = "";
                    while ((trimmed = reader.ReadLine()) != null)
                    {
                        if (trimmed != outPut)
                        {
                            permLine_ += trimmed + "\r\n";
                        }                        
                    }
                }
                //Now permLine_ contains the correct string
            }
        }                
    }
