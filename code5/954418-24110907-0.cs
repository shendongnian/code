        private void phoneNumberValidity(object sender, EventArgs e)
        {
            counter4 = Convert.ToInt32(IsPhoneNumberCorrect(textBoxPhoneNumber.Text));
            pictureBoxPhoneNumber.Image = imageList1.Images[counter4];
            if (Regex.IsMatch(textBoxPhoneNumber.Text, "[^0-9-+]"))
            {
                Regex regex = new Regex("[^0-9-+]");
                string output = regex.Replace(Clipboard.GetText(), "");
                textBoxPhoneNumber.Text = output;
            }
            checkIfOk();
            textBoxPhoneNumber.Focus();
            }
