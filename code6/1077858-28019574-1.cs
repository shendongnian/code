        private void button3_Click(object sender, EventArgs e)
        {
            getMethod(textBox1,5);
        }
       
        public static void getMethod(TextBox textbox1,int x)
        {
            if (x > 4)
            {
                textbox1.AppendText("Text");
            }
            else
            {
                textbox1.AppendText("Other text");
                otherVariable = x;
            }
        }
