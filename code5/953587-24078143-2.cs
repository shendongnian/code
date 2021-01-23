    int number1,number2;
    bool result1 = Int32.TryParse(TextBox_Tal1.Text, out number1);
    bool result2 = Int32.TryParse(TextBox_Tal2.Text, out number2);
    if(result1 && result2){
    // assign the result to the Text property
    Label_result.Text = plus(number1,number2).ToString();
    }
    
