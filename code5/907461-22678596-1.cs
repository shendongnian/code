    private void OpenDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenDataButton.Enabled = false;
                if (!OpenDataBackgroundWorker.IsBusy)
                {
                    OpenFileDialog openData = new OpenFileDialog();
                    openData.Multiselect = true;
                    openData.ShowDialog();
                    openData.Filter = "allfiles|*";
                    if (openData.FileName != "")
                    {
                        ClearInputDataTable();
                        LoadInputData();
                        OpenDataBackgroundWorker.WorkerReportsProgress = true;
                        OpenDataBackgroundWorker.WorkerSupportsCancellation = true;
                        OpenDataBackgroundWorker.RunWorkerAsync(openData.FileName);
                    }
                }
                //here!!!
                LoadInputData();
                OpenDataButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - Open Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
