        private void button4_Click(object sender, EventArgs e) {
         double result;
         if (c == "+") {
        
            num2 = double.Parse(textBox1.Text.Split('+')[1]);//bad idea but will work
            result = num1 + num2;
            textBox1.Text = result.ToString();
        }
     }
