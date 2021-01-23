    private void BtnSelect_Click(object sender, EventArgs e)
            {
                frm.ShowDialog();
                textBox1.Text= frm._textBox1.ToString();
            }
            public string _textBox
            {
                set { textBox1.Text = value; }
            }
