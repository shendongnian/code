    private void UpdateSubmitButton()
    {
        if (String.IsNullOrEmpty(textBox5.GetError) &&
            String.IsNullOrEmpty(textBox6.GetError))
        {
            button2.Visible = true;
        }
        else
        {
            button2.Visible = false;
        }
    }
    private void textBox5_TextChanged(object sender, EventArgs e)
    {
        int num;
        bool isNum = int.TryParse(textBox5.Text.Trim(), out num);
        if (!isNum)
        {
            errorProvider1.SetError(this.textBox5, "Please enter numbers");   
        }
        else
        {
            errorProvider1.SetError(this.textBox5, "");
        }
        UpdateSubmitButton();
    }
    private void textBox6_TextChanged(object sender, EventArgs e)
    {
        int num;
        bool isNum = int.TryParse(textBox6.Text.Trim(), out num);
        if (!isNum)
        {
            errorProvider2.SetError(this.textBox6, "Please enter numbers");
        }
        else
        {
            errorProvider2.SetError(this.textBox6, "");
        }
        UpdateSubmitButton();
    } 
