    public partial class Settings : Form
    {
        public string TemsPath
        {
            get { return txtTemsPath.Text; }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            // ... your save code ...
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
