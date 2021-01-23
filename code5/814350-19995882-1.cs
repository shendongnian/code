     public partial class Form2 : Form
    {
        string textToTransfer = "";
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textToTransfer = textBox1.Text;
            transfer(true);
            this.Close();
        }
        public string transfer(Boolean wantToTransfer) //You could also do this without the Boolean
        {
            if (wantToTransfer == true)
            {
                textToTransfer = "Succes";
            }
            else
            {
                textToTransfer = "nope";
            }
            return textToTransfer;
        }
