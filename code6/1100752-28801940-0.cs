    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker bckw = (BackgroundWorker)sender; // Recommended way, thread safe
        try
        {
            if (string.IsNullOrEmpty(saveFilePath))
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    btnBrowseSave.PerformClick();
                }));
            }
            if (!string.IsNullOrEmpty(saveFilePath))
            {
                if (dragEventArgs != null)
                    files = (string[])dragEventArgs.Data.GetData(DataFormats.FileDrop);
                int filesCount = 0, rowsCount = 0;
                foreach (string file in files)
                {
                    filesCount++;
                    double fileTotalLines = File.ReadAllLines(file).Length;
                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        lblFileName.Text = "Loading file: " + file.Substring(file.LastIndexOf("\\") + 1);
                        lblTotalFiles.Text = "File " + filesCount + " of " + files.Length;
                    })); // Invoke async, way too fast this...
                    using (StreamReader reader = new StreamReader(file))
                    {
                        using (StreamWriter writer = new StreamWriter(saveFilePath))
                        {
                            while (!reader.EndOfStream)
                            {
                                try
                                {
                                    while (stopPosition > rowsCount)
                                    {
                                        reader.ReadLine();
                                        rowsCount++;
                                    } // why are you using that? it won't get TRUE
                                    string email = reader.ReadLine().Trim();
                                    if (!string.IsNullOrEmpty(email) && !dicEmails.ContainsKey(email))
                                    {
                                        dicEmails.Add(email, null);
                                        writer.WriteLine(email);
                                    }
                                    rowsCount++;
                                    stopPosition++;
                                    bckw.ReportProgress((int)Math.Round(rowsCount * 100 / fileTotalLines, 0), (int)ProgressType.Row);
                                    if (bckw.CancellationPending)
                                        return;
                                }
                                catch (Exception ex)
                                {
                                    hadReadErrors = true;
                                    throw; // Throw it again, or you won't know the Exception
                                }
                            }
                        }
                    }
                    bckw.ReportProgress(0, (int)ProgressType.Row);
                    bckw.ReportProgress((filesCount * 100 / files.Length), (int)ProgressType.File);
                }
            }
        }
        catch (Exception ex)
        {
            hadReadErrors = true;
            MessageBox.Show(ex.Message);
        }
        finally
        {
            bckw.Dispose();
        }
    }
    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        //try
        //{
        switch ((int)e.UserState)
        {
            case (int)ProgressType.Row:
                lblFileProgress.Text = e.ProgressPercentage + "%";
                if (e.ProgressPercentage <= fileProgressBar.Maximum)
                    fileProgressBar.Value = e.ProgressPercentage;
                break;
            case (int)ProgressType.File:
                lblTotalProgress.Text = e.ProgressPercentage + "%";
                totalProgressBar.Value = e.ProgressPercentage;
                break;
        }
        //}
        //catch (Exception ex) { } // Don't catch everything
    }
