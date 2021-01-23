    try
        {
            using (StreamReader sr = new StreamReader(selectedProduct + ".txt"))
            {
                string line;
                int l = 0;
                // build the ftp link records line by line
                while ((line = sr.ReadLine()) != null)
                {
                    Label lFTPtextext = new Label()
                     {
                        AutoSize = true,
                        Text = line,
                        Tag = l
                     };
                    Button bt = new Button()
                     {
                       Text = "Copy Link",
                       Tag = l
                     }
                     
                     bt.Click += bt.Click;
                    TextBox tb = new TextBox()
                    {
                       Tag = l
                    }
                    flp.Controls.Add(lFTPtextext);
                    flp.Controls.Add(tb);
                    flp.Controls.Add(bt);
                    l++;
                }
                ftpGroupBox.Controls.Add(flp);
            }
        }
        // If the read fails then output the error message in the same section
        catch (Exception ex)
        {
            Label ftpErrorLabel = new Label();
            ftpErrorLabel.AutoSize = true;
            ftpErrorLabel.ForeColor = Color.Red;
            ftpErrorLabel.Text = "Error: " + ex.Message;
            flp.Controls.Add(ftpErrorLabel);
            ftpGroupBox.Controls.Add(flp);
        }
    }
    void bt_Click(object sender, EventArgs e)
        {
            string tagNumber = ((Button)sender).Tag.ToString();
            var tbText = from x in this.Controls.OfType<TextBox>()
                            where x.Tag.ToString() == tagNumber
                            select x.Text;
            var lblText = from x in this.Controls.OfType<Label>()
                             where x.Tag.ToString() == tagNumber
                             select x.Text;
            MessageBox.Show(tbText.ToString() + " " + lblText.ToString());
        }
