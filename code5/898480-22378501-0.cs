    public class Form1 : Form
    {
        public Button button1 = null;
        public void SomeMethod()
        {
            Button b = new Button();
            b.Name = "dynabutt";
            this.Controls.Add(b);
            button1 = b;
            button1.BackColor = Color.Blue;
        }
        public void button2_Click(...)
        {
            button1.BackColor = Color.Red;
        }
    }
