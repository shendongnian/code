    public partial class MyMainForm : System.Windows.Forms.Form
    {
        private async void btn_doWork_Click(object sender, EventArgs e)
        {
            MyProgressBarForm progressForm = new MyProgressBarForm();
            progressForm.Show();
            Progress<string> progress = new Progress<string>();
            progress.ProgressChanged += (_, text) =>
                progressForm.updateProgressBar(text);
            await Task.Run(() => RunComparisons(progress));
            progressForm.Close();
        }
        private void RunComparisons(IProgress<string> progress)
        {
            foreach (var s in nodeCollection)
            {
                Process(s);
                progress.Report("hello world");
            }
        }
    }
    public partial class MyProgressBarForm : System.Windows.Forms.Form
    {
        public void updateProgressBar(string updatedTextToDisplay)
        {
            MyProgressBarControl.Value++;
            myLabel.Text = updatedTextToDisplay;
        }
    }
