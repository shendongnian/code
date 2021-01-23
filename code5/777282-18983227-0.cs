    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            //Do Stuff: e.g. read from DB
            var tasks = GetTasks();
            
            int i = 0;
            double percentageIncrease = 100d / tasks.Count();
            foreach(var task in tasks)
            {
                //do something for this task
                backgroundWorker1.ReportProgress((int)(percentageIncrease * i));
                i++;
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
        }
    }
