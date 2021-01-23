    public partial class Form1 : Form
    {
        string steamPath = null; // set to starting path
        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            bool valueChanged = false;
            using (ConfigForm form = new ConfigForm())
            {
                form.newPath = null;
                form.ShowDialog();
                if (form.newPath != null)
                {
                    steamPath = form.newPath;
                    valueChanged = true;
                }
            }
            if (valueChanged)
            {
                // here is where you would handle reloading and changing the ComboBoxes
            }
        }
    }
