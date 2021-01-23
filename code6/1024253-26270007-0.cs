    namespace SomeApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // For each line in the rich text box...
                for (int i = 0; i < richTextBox.Lines.Length; i++)
                {
                    // Show a message box with its contents.
                    MessageBox.Show(richTextBox.Lines[i]);
                }
            }
        }
    }
