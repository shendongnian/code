    private void btnNext_Click(object sender, EventArgs e)
	{
    BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.ProgressChanged += (se, eventArgs) => {
				this.progressBar.Maximum = 100;
				this.progressBar.Minimum = 0;
				this.progressBar.Value = eventArgs.ProgressPercentage;
				lblStatus.Text = eventArgs.UserState as String;
				lblPercentage.Text = String.Format("Progress: {0} %", eventArgs.ProgressPercentage);
			};
	worker.DoWork += (se, eventArgs) => {
		int progress = 0;
		((BackgroundWorker)se).ReportProgress(progress, "Initializing the files...");
        //Process that takes a long time
        //Formula to calculate Progress Percentage 
        //This is how I calculated for my program. Divide 100 by number of loops you have
		int findPercentage = ((i + 1) * 100) / salesHeaderArr.Count;
		progress = 0;
		progress += findPercentage / 2;
        //Report back to the UI
		string progressStatus = "Importing Sales Header... (" + getSourceFileName(sourceFilePath) + ")";     
	    ((BackgroundWorker)se).ReportProgress(progress, progressStatus);
       //After Iterating through all the loops, update the progress to "Complete"
       ((BackgroundWorker)se).ReportProgress(100, "Complete...");
    };
    worker.RunWorkerCompleted += (se, eventArgs) =>
			{
				//Display smth or update status when progress is completed
				lblStatus.Location = new Point(20, 60);
				lblStatus.Text = "Your import has been completed. \n\nPlease Click 'Finish' button to close the wizard or \n'Back' button to go back to the previous page.";
				lblPercentage.Visible = false;
				progressBar.Visible = false;
				btnBack.Enabled = true;
				btnFinish.Enabled = true;
			};
			worker.RunWorkerAsync();
    }
