            private void searchReplaceBtn_Click(object sender, EventArgs e)
            {
                Form2 frm = new Form2();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    searchText();
                }
            }
