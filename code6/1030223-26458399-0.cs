     using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.Linq;
     using System.Text;
     using System.Windows.Forms;
     namespace Number_guessing_game
     {
        public partial class Form1 : Form
    {
        int montH;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myFunction();      
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
        Random rnd = new Random();
        int montH = rnd.Next(1, 10);
        }
        void myFunction()
        {
            int guess = int.Parse(textBox1.Text);
            if (guess == montH)
            {
                MessageBox.Show("You win!");
            }
            if (guess != montH)
            {
                MessageBox.Show("You lose!");
            }
        }
    }
}
