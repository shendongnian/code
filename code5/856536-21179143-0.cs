    string PrinterName
    {
        get { return (string)Properties.Settings.Default["PrinterName"]; }
        set 
        { 
            Properties.Settings.Default["PrinterName"] = value;
            Properties.Settings.Default.Save(); 
        }
    }
    private void print_Click(object sender, EventArgs e)
    {
        PrintDialog pd = new PrintDialog();
        if (PrinterName != "")
            pd.PrinterSettings.PrinterName = PrinterName;
        if (pd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            // Print
            PrinterName = pd.PrinterSettings.PrinterName;
        }
    }
