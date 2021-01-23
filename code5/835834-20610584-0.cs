           private void button1_Click(object sender, EventArgs e)
            {
                for(int i=50;i<83;i++)
                {
                    this.Controls.Find("label" + i,true)[0].Text = String.Empty;
                }
            }
