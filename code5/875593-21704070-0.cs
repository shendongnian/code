    using System;
    using System.Windows.Forms;
    using System.Drawing;
 
    namespace KeyPressDisplayTextBox {
    public partial class Form1 : Form {
        private TextBox textBox1;
        private Label label1;
 
        public Form1() {
            InitializeComponent();
        }
 
        private void Form1_Load(object sender, EventArgs e) {
            textBox1 = new TextBox();
            textBox1.Location = new Point(10,10);
            textBox1.KeyPress += textBox1_KeyPress;
            Controls.Add(textBox1);
 
            label1 = new Label();
            label1.Location = new Point(10, 40);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Arial", 14);
            Controls.Add(label1);
        }
 
        void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            label1.Text = e.KeyChar.ToString();
        }
     }
    }
