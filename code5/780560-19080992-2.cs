	using System;
	using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			private int firstNum = 2;
			private int secondNum = 4;
			private int answer;
			public Form2()
			{
				InitializeComponent();
				operatorListBox1.Items.Add("+");
				operatorListBox1.Items.Add("-");
				operatorListBox1.Items.Add("*");
				operatorListBox1.Items.Add("/");
                //this next line would go in your designer.cs file.  I put it here for completeness
                this.operatorListBox1.SelectedIndexChanged += new System.EventHandler(this.operatorListBox1_SelectedIndexChanged);
			}
			private void operatorListBox1_SelectedIndexChanged(object sender, EventArgs e)
			{
				calculateAnswer(((ListBox)sender).SelectedItem.ToString());
			}
			private void calculateAnswer(string sign)
			{
				switch (sign)
				{
					case "+":
						answer = firstNum + secondNum;
						break;
					case "-":
						answer = firstNum - secondNum;
						break;
					case "*":
						answer = firstNum * secondNum;
						break;
					case "/":
						answer = firstNum / secondNum;
						break;
				}
				textBox4.Text = firstNum + " " + sign + " " + secondNum + " = " + answer;
			}
		}
	}
