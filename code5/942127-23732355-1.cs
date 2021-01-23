    protected void FillForm(object sender, EventArgs e)
    {
        string inputString;
        textBoxContents.Text = "";
        using (StreamReader streamReader = File.OpenText(@"E:\file.txt"))
        {
            inputString = streamReader.ReadLine();
            //assign inputString value to title text box
            //set inputString value to ""
    
    
            while (inputString != null)
            {
                textBoxContents.Text += inputString + "<br />";
                inputString = streamReader.ReadLine();
            }
        }
    }
