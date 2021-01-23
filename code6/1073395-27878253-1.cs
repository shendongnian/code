    public partial class frmAcceptRevisions : Form
    {
        private List<Revision> _Revisions = null;
        public frmAcceptRevisions(List<Revision> Revisions)
        {
            InitializeComponent();
            this._Revisions = Revisions;
            this.Shown += frmAcceptRevisions_Shown;
        }
        private void frmAcceptRevisions_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < _Revisions.Count; i++)
            {
                backgroundWorker1.ReportProgress(i + 1);
                _Revisions[i].Accept();
                System.Threading.Thread.Sleep(1000); // for illustrative purposes only
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = "Applying Revision " + e.ProgressPercentage.ToString() + " of " + _Revisions.Count.ToString();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Revisions Accepted: " + _Revisions.Count.ToString());
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
