    while (sr.Peek() >= 0)
    {
    	string line = sr.ReadLine(); // store the value in a variable
    	if (!String.IsNullOrWhiteSpace(line)) // check if not empty
    	{
    		string[] val = line.Split(','); // assuming it returns three values
            
            // you can add extra validation here
            // array should have 3 values
            // otherwise it will throw invalid index exception
    		emp.Add(new Employee(val[0], val[1], Convert.ToInt32(val[2])));
    	}
    }
    return emp;
