    private void regBtnTextChanged(object sender, EventArgs e)
        {
            if (regTxtBoxName.TextLength<4) {
                regTxtBoxName.BackColor = Color.Red;
            }
            else{
                regTxtBoxName.BackColor = Color.DarkBlue;
            }
        }
