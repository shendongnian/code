    public partial class CtlCustom: UserControl
    {
        public CtlSuggestion()
        {
            this.MouseWheel += new MouseEventHandler(this.UserControl_MouseWheel);
            this.CtlTextbox.MouseWheel += new MouseEventHandler(this.CtlTextBox_MouseWheel);
        }
        private void UserControl_MouseWheel(object sender, MouseEventArgs e)
        {
        }
        private void CtlTextBox_MouseWheel(object sender, MouseEventArgs e)
        {
        }
    }
