    public void Run()
    {
    	Person Bob = New Person();
    	Bob.LikesToProgram = false;
    	Helper(Bob);
    	Console.WriteLine("Bob likes to program = " + Bob.LikesToProgram);
    	//Output: Turns out Bob likes to program!!!
    }
    
    public void Helper(Person input)
    {
    	input.LikesToProgram = true;
    }  
  
