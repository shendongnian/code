    using System;
    using System.Windows.Forms;
    namespace ComboBox
    {
    public class Temp : Form
    {
        public Temp()
        {
            this.Text = "Bitsforge";
        }
    }
    public class Emp : Form
    {
        public Emp()
        {
            this.Text = "Yes Bank";
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (combo.SelectedItem.ToString() == "Yes Bank")
            {
                Emp newForm = new Emp();
                newForm.Show();
                this.Hide();
            }
            else if (combo.SelectedItem.ToString() == "Bitsforge")
            {
                Temp newForm = new Temp();
                newForm.Show();
                this.Hide();
            }
        }
    }
