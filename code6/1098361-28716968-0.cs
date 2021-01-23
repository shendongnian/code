    // this list will contain the results
    List<string> list = new List<string>();
    // create an array of allowed operators
    string[] operators = new string[] { "+", "-", "*" };
    Random randonNum = new Random();
    for (int i = 0; i < 200; i++)
    {
        // pick two numbers
        int num1 = randonNum.Next(0, 500); 
        int num2 = randonNum.Next(0, 500); 
        // pick an operator from the array
        string oper = operators[randonNum.Next(operators.Length)];
        // add it to the list
        list.Add(string.Format("{0}{1}{2}", num1, oper, num2));
    }
