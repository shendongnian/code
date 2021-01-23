    private void button1_Click(object sender, EventArgs e)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            int lineNumber = 0;
            while (!sr.EndOfStream)
            {
               lineNumber++;
               var readLine = sr.ReadLine();
               if (readLine != null)
               {
                   TextBox textBox = GetControle(this, "textBox"+lineNumber);
                    if (textBox != null)
                    {
                        textBox.Text = readLine;
                    }
                }
            }
         }
    }
   
    private TextBox GetControle(Control ctrlContainer, string name)
    {
        foreach (Control ctrl in ctrlContainer.Controls)
        {
            if (ctrl.GetType() == typeof(TextBox))
            {
                if (ctrl.Name == name)
                {
                    return (TextBox)ctrl;
                }
            }
             if (ctrl.HasChildren)
                GetControle(ctrl, name);
        }
        return null;
    }
