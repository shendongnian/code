            private void RunFileOperation(string inputFile, string search)
        {
            Timer t = new Timer();
            StringBuilder sb = new StringBuilder();
            {
                rtbLog.Text = "Start Deleting...\n";
            }
   
            // Filesize serves as max value to check progress
            progressBar1.Maximum = (int)(new FileInfo(inputFile).Length);
            t.Tick += (s, e) =>
            {
                rtbLog.Text += sb.ToString();
                progressBar1.Value = progress;
                if (progress == progressBar1.Maximum)
                {
                    t.Enabled = false;
                    tssLbl.Text = "done";
                }
            };
            //update every 0.5 second       
            t.Interval = 500;
            t.Enabled = true;
            // Start async file read operation
            if (rbtnDelete.Checked)
            {
                if (cbDelete.Checked)
                {
                    System.Threading.Tasks.Task.Factory.StartNew(() => delete_Lines(inputFile, search, ref progress, ref sb, ref res1));
                }
        }
        else 
        {
           //..do something
        }
        private void delete_Lines(string fileName, string searchString, ref int progress, ref      StringBuilder sb, ref StringBuilder res1)
        {
        bool checkNextLine=false;
            using (var file = File.OpenText(fileName))
            {
                int i = 0;
                while (!file.EndOfStream)
                {
                    i++;
                    var line = file.ReadLine();
                    progress = (int)file.BaseStream.Position;
                    if (line.Contains(searchString))
                    {
                        sb.AppendFormat("Deleting(row {0}):\n{1}\n", (i), line);
                        checkNextLine = true;
                    }
                    else
                    {
                        if (cbDB && checkNextLine && line.StartsWith(" "))
                        {
                            sb.AppendFormat("{0}\n", line);
                        }
                        else
                        {
                            checkNextLine = false;
                            res1.AppendLine(line);
                        }
                    }
                    
                }
            }
            sb.AppendLine("\n...Deleting finished!);
        }
