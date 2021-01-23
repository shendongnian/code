    public static void writePerm(System.Windows.Forms.Form targetForm)
    {
        StreamWriter writer;
        string trimmed = "", outPut = "";
        int count;
        foreach (Control C in targetForm.Controls)
        {
            if (C.GetType() == typeof(CheckBox))
            {
                if ( ((CheckBox)C).Checked == true ) { C.Visible = false; }
                else
                {
                    count = C.Name.Count();
                    trimmed = C.Name.ToString();
                    outPut += trimmed.Remove(count - 4) + "\r\n";
                }
            }
        }
        
        if (outPut != "")
        {
            outPut = outPut.Remove(outPut.Length - 2); //trim the last \r\n
        }
        using (writer = new StreamWriter(dataFolder + PermFile))
        {
             writer.WriteLine(outPut);
        }
    }
