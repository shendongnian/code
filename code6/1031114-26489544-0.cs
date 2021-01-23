    private List <string> text = new List <string>();
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
                while ((permLine = reader.ReadLine()) != null)
                {
                    if (permLine != outPut)
                    {
                        text.Add(permLine + "\r\n");
                    }
                }
            }
            text[text.Count - 1] = text[text.Count - 1].Replace("\r\n", "");
            permLine = String.Join(String.Empty, text);
        
            //and write permLine to file    
            //writer = writePerm();
        }            
        else
        {
        }     
        if (text.Count != 0)
        {
            text.Clear();
        }
    }
