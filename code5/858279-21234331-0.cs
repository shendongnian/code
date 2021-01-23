        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var folder = new DirectoryInfo(@"C:\Cloud24");
            try
            {
                {
                    var manualResetEvent = new ManualResetEventSlim();
                    var client = new WebClient { Credentials = new NetworkCredential(userid, userpass) };
                    client.DownloadProgressChanged += (o, args) => backgroundWorker1.ReportProgress(args.ProgressPercentage);
                    client.DownloadDataCompleted += (o, args) => manualResetEvent.Set();
                    var filedata = client.DownloadDataAsync(ftpadress + "/" + downloadname);
                    manualResetEvent.Wait();
                    using (var stream = File.Create(folder + "//" + downloadname))
                    {
                        await stream.WriteAsync(filedata, 0, filedata.Length);
                    }
                    MessageBox.Show(downloadname + " downloaded!" + Environment.NewLine + "There: " + folder);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }
