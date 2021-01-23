    public partial class frmAdd : Form 
    { 
        int first;   // changed to int
        int second;
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumber.Text, out this.first))
            {
                MessageBox.Show("Invalid Input!");
            }
        }
        private void btnSecond_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumber.Text, out this.second))
            {
                MessageBox.Show("Invalid Input!");
            }
        }
        private void btnResult_Click(object sender, EventArgs e)
        {
            int c = first + second;
            txtResult.Text = c.ToString();
        }
    }
