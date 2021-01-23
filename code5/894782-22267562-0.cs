    string txtData = this.txtTextBox.Text;
            string[] splitByCRet = txtData.Split(new string[]{"\r\n"},  StringSplitOptions.None );
            if (splitByCRet.Length > 6)
            {
                //Exceeds the limit;
                MessageBox.Show("Exceeds");
            }
            else
            {
                MessageBox.Show("Ok to proceed");
            }
