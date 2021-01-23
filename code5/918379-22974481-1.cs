    string inputFile;
    string outputFile;
     
    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            inputFile = openFileDialog1.FileName;
            lblInputFile.Text = inputFile;
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        DialogResult result = saveFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            outputFile = saveFileDialog1.FileName;
            lblOutputFile.Text = outputFile ;
        }
    }
    private void button3_Click(object sender, EventArgs e)
    {
        string line;
        using(StreamReader pizza = new StreamReader(inputFile))
        using(StreamWriter burger = new StreamWrite(outputFile))
        {
            while ((line = pizza.ReadLine()) != null)
            {
               if (!string.IsNullOrWhiteSpace(line) && filter(line))
                   burger.WriteLine(line);
            }
        }
        MessageBox.Show("Output File Written");
    }
    private Boolean filter(string intext)
    {
        string gender = intext.Substring(0, 1);
        string state = intext.Substring(0, 1);
        if (((radioButtonFemale.Checked && gender.Equals("F")) ||
             (RadioButtonMale.Checked && gender.Equals("M"))))
             return true;
        else
             return false;
    }
