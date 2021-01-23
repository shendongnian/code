    public void Process()
    {
        // Execute Step 1
        Result.Step1Result = Step1();
        Result.IsStep1Valid = true;
       
        Result.Step2Result = Step2();
        Result.IsStep2Valid = true;
        // Other Steps ( long - running )
    }
