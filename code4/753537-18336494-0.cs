    namespace myParser
    {
    public partial class Form1 : Form
    {
        string filePath;
        string[] files;
        int fileCount = 0;
        int numberOfFiles;
        int lineCount = 0;
        int numberOfLines;
        public Form1()
        {
            InitializeComponent();
            pbFilesProcessed.Visible = false;
            pbLinesProcessed.Visible = false;
            btnParse.Visible = false;
            lbProcessedFiles.Visible = false;
            lbProcessedLines.Visible = false;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //counts the number of files in the folder
                files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                filePath = folderBrowserDialog1.SelectedPath.ToString();
                char[] delimiterChars = { '\\' };
                string[] filePathParts = filePath.Split(delimiterChars);
                string folder = filePathParts[4];
                tbFolderName.Text = folder;
                btnParse.Visible = true;
            }
        }
        private void btnParse_Click(object sender, EventArgs e)
        {
            btnParse.Visible = false;
            btnOpen.Visible = false;
            lbProcessedFiles.Visible = true;
            pbFilesProcessed.Visible = true;
            lbProcessedLines.Visible = true;
            pbLinesProcessed.Visible = true;
            lbProcessedLines.Text = "Lines: 0 / 0";
            pbFilesProcessed.Maximum = Convert.ToInt32(files.Length.ToString());
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var csvFile in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
            {
                numberOfFiles = Convert.ToInt32(files.Length.ToString());
                string fileName = "Waveforms.csv";
                lineCount = 0;
                string lines;
                string newLines;
                string csvFullFilePath = csvFile.ToString();
                string[] filePathSplit = csvFullFilePath.Split('\\');
                string pointName = filePathSplit[4].ToString();
                string[] pathDirectionSplit = filePathSplit[5].ToString().Split('_');
                string[] swingDirectionSplit = pathDirectionSplit[3].Split('.');
                string swingDirection = swingDirectionSplit[0];
                
                numberOfLines = File.ReadLines(csvFile).Count();
                using (StreamReader r = new StreamReader(csvFile))
                {
                    while ((lines = r.ReadLine()) != null)
                    {
                        if (lineCount == 0)
                        {
                            lines.Remove(0);
                            lineCount++;
                        }
                        else
                        {
                            newLines = Regex.Replace(lines, ",{2,}", ",").ToString();
                            File.AppendAllText(@"Simulator\\" + fileName, pointName + "," + swingDirection + "," + newLines + System.Environment.NewLine);
                            backgroundWorker1.ReportProgress(lineCount);
                            lineCount++;
                        }
                    }
                    r.Close();
                }
                backgroundWorker1.ReportProgress(fileCount);
                fileCount++;
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbFilesProcessed.PerformStep();
            lbProcessedFiles.Text = "Files: " + fileCount.ToString() + "/" + files.Length.ToString();
            pbLinesProcessed.PerformStep();
            lbProcessedLines.Text = "Lines: " + lineCount + "/" + Convert.ToInt32(numberOfLines.ToString());
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnParse.Visible = false;
            MessageBox.Show("Done");
            btnOpen.Visible = true;
        }  
    }
}
