    Test[] test1 = new Test[2];
    List<Test> test2 = new List<Test>();
    test1[0] = new Test();   //initialized here 
    test1[0].A = 1;
    test1[0].B = "t";
    test1[1] = new Test();  //initialized here 
    test1[1].A = 2;
    test1[1].B = "y";
    test2.AddRange(test1);  // Use Add range method
