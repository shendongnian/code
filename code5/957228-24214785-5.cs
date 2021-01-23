    public partial class mainForm : Form
    {
        updateForm Uform;
        private void cb_update_Click(object sender, EventArgs e)
        {
            if (Uform == null)  Uform = new updateForm(this);
            Uform.Show();
        }
    }
