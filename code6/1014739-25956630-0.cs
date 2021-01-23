     /* Here you are passing pointer to the variable. For example variable test has got memory address
                 * 0X200001.
                 * When you pass test, you are saying that there are two variables that points to 0X200001 (one in main and another in CallFunctionByObjectRef i.e. variable a)
                 * Thus when you are changing the value for a variable to null, you are changing the direction to link with null memory location.
                 * 
                 * It is called  reference.
                 * When you came back to Main, test variable is still pointing to the memory 0X200001
                */
                Test test = new Test();
                test.Name = "ABC";
    
                test.CallFunctionByObjectRef(test);
    
                /*
                * In this case you are saying that create a variable test1 that gives a memory as: 0X200002
                * Then you are passing a pointer to pointer i.e. you are sending an actual test1 variable. 
                 * so whatever you will change here will get impacted in Main.
                */
                Test test1 = new Test();
                test1.Name = "ABC";
                
                test1.CallFunctionByObjectRefTORef(ref test1);
    
                Console.WriteLine(test.Name);
                Console.WriteLine(test1.Name);
                Console.Read();
