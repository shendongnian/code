    public class DragDropRichTextBox : RichTextBox
    {
        public static string Name;
        public DragDropRichTextBox()
        {
            //Enables drag and drop on this class.
            this.AllowDrop = true;
            this.DragDrop += DragDropRichTextBox_DragDrop;
        }
        public void DragDropRichTextBox_DragDrop(object sender, DragEventArgs e)
            {
                string[] _fileText;
                _fileText = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (_fileText != null)
                {
                    foreach (string name in _fileText)
                    {
                        try
                        {
                            this.AppendText(BinaryFile.ReadString(name);
                            Name = name;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }       
    }
    private void button5_Click(object sender, EventArgs e)
        {
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                if (DialogResult.OK == pd.ShowDialog(this))
                {                        
    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, DragDropRichTextBox.Name);
                }
        }
