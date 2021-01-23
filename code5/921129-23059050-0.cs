    private void btnMove_Click(object sender, EventArgs e)
            {
                string check = txtCheck.Text;
                string status = "";
                for (int i = 0; i < check.Length; i++)
                {
                    if (IsNumber(check[i]))
                    status+="The char at "+i+" is a number\n";
                }
                MessageBox.Show(status);
            }
            private bool IsNumber(char c)
            {
                return Char.IsNumber(c);
            }
