	using System;
	using System.Windows.Forms;
	namespace WindowsFormsApplication2
	{
		public partial class Form2 : Form
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
				textBox2.Text = firstNum + " " + sign + " " + secondNum + " = " + answer;
			}
		}
	}
