    public class Form2 : Form
    {
        public event Action<string> TextChanged; //TODO consider renaming
    
        private void button1_Click(object sender, EventArgs e)
        {
            var handler = TextChanged;
            if(handler != null)
                handler(textbox.Text);
        }
    }
