    private void OpenDataBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //LoadInputData();
                CalculateRowAndColumnInNumericUpDown();
                mainForm.MainToolStripProgressBar.Value = 0;
                this.Cursor = Cursors.Default;
                OpenDataButton.Enabled = true;
                ProcessGroupBox.Enabled = true;
                ClearAllDataButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Open Data Background Worker RunWorkerCompleted Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
