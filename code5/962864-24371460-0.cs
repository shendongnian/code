    class ConfigForm : Form 
    {
        public string newPath = null;
        public void CloseButton_Click(object sender, EventArgs e)
        {
            newPath = NewPathBox.Text;
        }
        public void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
