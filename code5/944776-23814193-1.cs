    public partial class frmReservations : Form
    {
        public string yourDesiredResult = string.Empty;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.yourDesiredResult = "I've been set!";
            this.Close();
        }
    }
