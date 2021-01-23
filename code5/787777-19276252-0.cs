    string str = "~!@#$%^&*()_+{}:"<>?";
                int count = 0;
                foreach (char c in str)
                {
                    if (!char.IsLetterOrDigit(c.ToString(),0))
                    {
                        count++;
                    }
                }
                MessageBox.Show(count.ToString());
