    public class Form2 : Form
    {
        public void Display()
        {
            ShowDialog();
            Form3 dialog = new Form3();
            //TODO pass in parameters
            dialog.ShowDialog();
        }
    }
