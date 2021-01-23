            string[] SplitString(string S)
            {
                return S.Split('া');
            }
            private void button1_Click(object sender, EventArgs e)
            {
                string B = "সাজানো";
                var vv = SplitString(B);
                foreach (var item in vv)
                {
                    MessageBox.Show(item.ToString());
                }
            }
