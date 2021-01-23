    private void button1_Click(object sender, EventArgs e)
        {
            Max = int.Parse(textBox1.Text);
            fun = new TextBox[Max];
            for (int i = 0; i < Max; i++)
            {
                if (i > 0)
                {
                    y = y + 26;
                }
                fun[i] = new TextBox();
                fun[i].Location = new System.Drawing.Point(44, y);
                fun[i].Text = "Test";
                this.Controls.Add(fun[i]);
            }
        }
