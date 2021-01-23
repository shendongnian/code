    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication5
    {
    
        public partial class Form1 : Form
        {
            int number = new Random().Next(1, 100);
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void guessButton_Click(object sender, EventArgs e)
            {
    
                int userGuess;
                userGuess = int.Parse(guessText.Text);
                label2.Text = "" + number;
    
    
                if (userGuess > number)
                {
                    resultLabel.Text = "Your guess is too high";
                }
    
                else if (userGuess < number)
                {
                    resultLabel.Text = "Your guess is too low.";
                }
    
                else if (userGuess == number)
                {
                    resultLabel.Text = "That is correct!";
                }
    
                guessText.Clear();
    
    
    
            }
    
            private void exitButton_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
