    private void button2_Click(object sender, EventArgs e)
    {
        if (this.worker != null && this.worker.IsBusy)
        {
            this.worker.CancelAsync();
            return;
        }
    
        string[] addr = new string[] {".... our full addresss lists" };
    
        this.progressBar1.Maximum = addr.Length;
        this.progressBar1.Value = 0;
        this.progressBar1.Visible = true;
        this.progressBar1.Enabled = true;
        this.worker = new BackgroundWorker();
        this.worker.WorkerSupportsCancellation = true;
        this.worker.WorkerReportsProgress = true;
        this.worker.ProgressChanged += (s, args) =>
        {
            this.progressBar1.Value = args.ProgressPercentage;
        };
    
        this.worker.RunWorkerCompleted += (s, args) =>
        {
            this.progressBar1.Visible = false;
            this.progressBar1.Enabled = false;
    
            if (args.Cancelled)
            {
                MessageBox.Show(this, "Cancelled");
                worker.Dispose();
                worker = null;
                return;
            }
    
            var img = args.Result as Bitmap;
            if (img == null)
            {
                worker.Dispose();
                worker = null;
                return;
            }
            this.pictureBox1.Image = img;
    
            MessageBox.Show(this, "Completed");
            worker.Dispose();
            worker = null;
        };
    
        this.worker.DoWork += (s, args) =>
        {
            Bitmap favCollection = new Bitmap(96, 64);
            Graphics g = Graphics.FromImage(favCollection);
    
            for (var i = 0; i < addr.Length; i++)
            {
                if (worker.CancellationPending)
                    break;
    
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    try
                    {
                        byte[] dl = client.DownloadData(addr[i]);
                        using (var stream = new MemoryStream(dl))
                        {
                            using (var dlImg = new Bitmap(stream))
                            {
                                g.DrawImage(dlImg, (i % 6) * 16, (i / 6) * 16, 16, 16);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        using (var dlImg = new Bitmap(Properties.Resources.defaultFacIcon))
                        {
                            g.DrawImage(dlImg, (i % 6) * 16, (i / 6) * 16, 16, 16);
                        }
                    }
                }
                if (worker.CancellationPending)
                    break;
    
                this.worker.ReportProgress(i);
            }
    
            if (worker.CancellationPending)
            {
                g.Dispose();
                favCollection.Dispose();
                args.Cancel = true;
                return;
            }
            args.Cancel = false;
            args.Result = favCollection;
        };
        worker.RunWorkerAsync();
    }
