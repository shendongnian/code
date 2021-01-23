    private void SaveToFile()
    {
        string taxpayerLine;
        string taxpayerFile = string.Empty;
        string myFileName;
        FileInfo myFile;
        using (SaveFileDialog taxpayerFileChooser = new SaveFileDialog())
        {
            taxpayerFileChooser.Filter = "All text files|*.txt";
            if (DialogResult.OK == taxpayerFileChooser.ShowDialog())
            {
                taxpayerFile = taxpayerFileChooser.FileName;
            }
        }
        if (!string.IsNullOrEmpty(taxpayerFile))
        {
            using (StreamWriter fileWriter = new StreamWriter(taxpayerFile, true))
            {
                foreach (Taxpayer tp in Taxpayers)
                {
                    taxpayerLine = tp.Name + "," +
                    tp.Salary.ToString() + "," +
                    tp.InvestmentIncome.ToString() + "," +
                    (tp.InvestmentIncome + tp.Salary).ToString() + "," +
                    tp.GetRate().ToString() + "," +
                    tp.GetTax().ToString();
                    fileWriter.WriteLine(taxpayerLine);
                }
            }
            myFile = new FileInfo(taxpayerFile);
            myFileName = myFile.Name;
            MessageBox.Show("Data Saved to " + myFileName);
        }
        else
        {
            MessageBox.Show("Data not saved");
        }
    }
