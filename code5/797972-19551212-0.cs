    public class frmProgressbar : Form
    {
        public event Action Canceled;
        void btnCancel_Click(object sender, EventArgs e)
        {
            if (Canceled != null)
                Canceled();
        }
        //other stuff
    }
