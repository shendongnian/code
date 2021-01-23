    public void Button1_Click(Object sender, EventArgs e)
    {
       string input1 = txtInput.Text;
       string input2 = txtInput2.Text;
  
       int userInput;
       int userInput2;
       int result;
       Int32.TryParse(input1, out userInput);
       Int32.TryParse(input2, out userInput2);
       result = userInput + userInput2;       
       txtAnswer.Text = "The answer is: " result.ToString(); 
    }
