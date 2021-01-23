        public void findspecific(int winnerx, int winnery)
        {
            string ineed = "tb" + winnerx.ToString() + winnery.ToString();
            Control[] matches = this.Controls.Find(ineed, true);
            if (matches.Length > 0 && matches[0] is TextBox)
            {
                TextBox tb = (TextBox)matches[0];
                tb.Text = "Something";
            }
            else
            {
                MessageBox.Show(ineed, "No Match Found!");
            }
        }
