    private int ValidInput(string operand1, string operand2, string mathSymbol, out decimal firstNumber, out decimal secondNumber out string errorMsg)
	{
		int errorCode  ;
		
        errorMsg = string.Emtpy ;
        firstNumber = 0 ;
        secondNumber = 0 ;
		try 
		{
			if ((mathSymbol != "/") && (mathSymbol != "*") && (mathSymbol != "+") && (mathSymbol != "-"))
            {
				errorCode = 1 ;
                errorMsg = "ERROR invalid operator";
            }	
			else
			{
				errorCode = 2 ;
				firstNumber = Convert.ToDecimal(operand1);
				
				if (firstNumber <= 0 || firstNumber >= 1000000)
				{
					errorCode = 3 ;
					errorMsg = "first number must be greater than 0 and less than 1,000,000" ;
				}
				else
				{
					errorCode = 4 ;
					secondNumber = Convert.ToDecimal(operand2);
					
					if (secondNumber <= 0 || secondNumber >= 1000000)
					{	
						errorCode = 5 ;
						errorMsg = "second number must be greater than 0 and less than 1,000,000" ;
					}
					else
					{
						errorCode = 0;
					}
				}
			
			}
		}
		catch (FormatException	fe)
		{
			errorMsg = fe.Message ;
		}
		catch (OverflowException oe)
		{
			errorMsg = oe.Message ;
		}
		return errorCode
	}
	private void btnCalculate_Click(object sender, EventArgs e)	
    {
		decimal firstNumber ;
		decimal secondNumber ;
		string mathSymbol = txtOperator.Text;   // already a string variable
		decimal result = 0;
		int errorCode ;
                string errorMsg ;
	
		errorCode = ValidInput(txtOperand1.Text.Trim(), txtOperand2.Text.Trim(), mathSymbol, out firstNumber, out secondNumber out errorMsg) ;
		
		//if there was no error
		if(errorCode == 0)
		{
			//calls the calculate method
			result = calculate(firstNumber, secondNumber, mathSymbol, result);
			
			//you can use the errorCode number to decide which fields to clear or provide more usefull message
		}
		else
		{
			MessageBox.Show(errorMsg, "ERROR");
		}
    }
