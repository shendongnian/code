    namespace WinClose
    {
        public partial class Form2 : Form
        {       
            private void button1_Click(object sender, EventArgs e)
            {
                foreach (var form in Application.OpenForms.OfType<Form1>().ToList())
                    form.Close ();
            }
        }
    }
