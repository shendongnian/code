    private void button1_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.SafeFileName;                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var validator = new OpenXmlValidator();
                int count = 0;
                foreach (ValidationErrorInfo error in validator.Validate(SpreadsheetDocument.Open(openFileDialog1.FileName, true)))
                {
                    lblError.Text += "\r\n";
                    count++;
                    lblError.Text += ("Error Count : " + count) + "\r\n";
                    lblError.Text += ("Description : " + error.Description) + "\r\n";
                    lblError.Text += ("Path: " + error.Path.XPath) + "\r\n";
                    lblError.Text += ("Part: " + error.Part.Uri) + "\r\n";
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                lblError.Text += (ex.Message);
            }
        }
