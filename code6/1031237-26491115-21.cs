    private void bModify_Click(object sender, EventArgs e)
    {
        StreamWriter writer;
        string trimmed = "", outPut = "";
        int count;
        foreach (Control C in this.Controls)
        {
            if (C.GetType() == typeof(System.Windows.Forms.CheckBox))
            {
                if (C.Checked == true){ C.Visible = false; }
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
