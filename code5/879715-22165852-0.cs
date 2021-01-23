    public class PrinterSettingsDlg : Form
    {
        PrinterSettings ps = new PrinterSettings();
        Button button1 = new Button();
        ComboBox combobox1 = new ComboBox();
        public PrinterSettingsDlg()
        {
            this.Load += new EventHandler(PrinterSettingsDlg_Load);
            this.Controls.Add(button1);
            this.Controls.Add(combobox1);
            button1.Dock = DockStyle.Bottom;
            button1.Text = "Change Printer Settings";
            button1.Click += new EventHandler(button1_Click);
            combobox1.Dock = DockStyle.Top;
        }
        void button1_Click(object sender, EventArgs e)
        {
            PrinterData pd = ps.GetPrinterSettings(PrinterName);
            pd.Size = ((PaperSize)combobox1.SelectedItem).RawKind;
            ps.ChangePrinterSetting(PrinterName, pd);
        }
        void PrinterSettingsDlg_Load(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = // printer name
            combobox1.DisplayMember = "PaperName";
            foreach (PaperSize item in pd.PrinterSettings.PaperSizes)
            {
                combobox1.Items.Add(item);
            }            
        }
    }
