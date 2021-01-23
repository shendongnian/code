    namespace Calculator
    {
        class DisplayUserData
        {
            private readonly GetUserInput _userInput;
            private readonly Calculator _calculator;
    
            DisplayUserData(GetUserInput userInput, Calculator calculator)
            {
                _userInput = userInput;
                _calculator = calculator;
            }
    
            public void DisplayCalculatedUserData()
            {
                decimal calculatedValue = _calculator.CalculateUserInput(_userInput.Choice, _userInput.ValueOne, _userInput.ValueTwo);
    
                switch (_userInput.Choice)
                {
                    case '1':
                        Console.WriteLine("Addition: " + _userInput.ValueOne + " + " + _userInput.ValueTwo + " = " + calculatedValue);
                        break;
                    case '2':
                        Console.WriteLine("Subtraction: " + _userInput.ValueOne + " - " + _userInput.ValueTwo + " = " + calculatedValue);
                        break;
                }
            }
        }
    }
