    MyContext testTableContext = new MyContext();
    TestTable1 testTable1 = new TestTable1();
    testTable1.value = 1215867935736100000;
    testTableContext.TestTable1.Add(testTable1);
    testTableContext.SaveChanges();
