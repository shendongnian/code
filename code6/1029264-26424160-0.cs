    public class Form1
    {
        private String _filePath = null;
        
        private void btnFiles_Click(object sender, EventArgs e)
        {
            //get your file and assign _filePath here...
            _filePath = folderBrowserDialog1.SelectedPath;
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //use _filePath here...
        }
    }
