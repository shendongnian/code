    void btn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        businessLogic.OnBtnClick(btn.Name);
    }
    String GetInput()
    {
        return txtInput;
    }
    void AddInput(String digit)
    {
         txtInput.Text += digit;
    }
