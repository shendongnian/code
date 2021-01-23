    public partial class Form1 : Form
    {
        private void button3_Click(object sender, EventArgs e)
        {
            Settings frm = new Settings();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label3.Text = frm.TemsPath;
            }
        }
    }
