     public partial class Form1 : Form
    {
        private Form2 frm2;
        public string[] nome = new string[6];
        public string[] sobrenome = new string[6];
        public string[]  sexo = new string[6];
        public string[] idade = new string[6];
        public int i = 0;
        
        public Form1()
        {
            
            InitializeComponent();
            frm2 = new Form2(this);
        }
        public void button1_Click(object sender, EventArgs e)
        {
            ++i; 
            nome[i] = textBox1.Text;
            sobrenome[i] = textBox2.Text;
            sexo[i] = comboBox1.Text;
            idade[i] = textBox3.Text;
            double num;
            bool isnum = double.TryParse(idade[i], out num);
            
            
            if (textBox1.Text !=null && textBox2.Text!=null && textBox3 != null && isnum == true)
            {
                frm2.comboBox1.Items.Add(textBox1.Text);
                frm2.comboBox1.Update();
                comboBox1.Update();
                if (i == 1)
                {
                    frm2.Show();
                    frm2.Location = new Point(this.Left + this.Width, this.Top);
                    frm2.Height = this.Height;
                }
                frm2.label6.Text = nome[i] + " "  + sobrenome[i];
                frm2.label8.Text = sexo[i];
                frm2.label9.Text = idade[i];
                frm2.comboBox1.SelectedIndex = frm2.comboBox1.SelectedIndex + 1;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();                
            }
            
             if(isnum == false && textBox1.Text == null && textBox2.Text == null && textBox3 == null)
            {
                MessageBox.Show("Preencha todos os campos", "Erro");
                --i;
            }
            if (i >= 5)
            {
                button1.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
