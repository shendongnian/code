    protected void FillForm(object sender, EventArgs e)
    {
        textBoxContents.Text = "";
        using (var streamReader = File.OpenText(@"E:\file.txt"))
        {
            string inputString = null;
            int lineNumber;
            do
            {
                inputString = streamReader.ReadLine();
                lineNumber++;
                // this
                // get line number 7
                if(lineNumber == 7)
                {
                     textBoxContents.Text += inputString + "<br />";
                     break;
                }
                // or perhaps this
                // get next line after line containing "Description"
                if(inputString.Contains("Description"))
                {
                     inputString = streamReader.ReadLine();
                     textBoxContents.Text += inputString + "<br />";
                     break;
                }
            } while (inputString != null)
        }
    }
