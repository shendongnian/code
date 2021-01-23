    public class AnotherForm
    {
        private MainForm mainF;
        public AnotherForm(MainForm mainF)
        {
            this.mainF = mainF;
        }
        ...
        ...
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ...
            mainF.inputTextBox.Text = input;
            ...
        }
    }
