          private void alphaCode_Click(object sender, EventArgs e)
           {
                char s = Convert.ToChar(alphaCode.Text.Trim());
                if (s == '-' || s == 'Z')
                {
                    alphaCode.Text = "A";
                }
                else
                {
                    s++;
                    alphaCode.Text = s.ToString();
                }
            }
