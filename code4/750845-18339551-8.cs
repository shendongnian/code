    class TestClass
    {
        static void Main()
        {
            // instantiate my facades
            TestFacade peterFacade = new TestFacade(PersonChoice.Peter);
            TestFacade charlesFacade = new TestFacade(PersonChoice.Charles);
            TestFacade bothFacade = new TestFacade(PersonChoice.Both);
    
            //      run some methods:
            // Peter
            string name = "Peter";
            int age = 15;
            writeProperties(peterFacade, name, age);
    
            // Charles
            name = "Charles";
            age = 20;
            writeProperties(charlesFacade, name, age);
    
            // Both
            name = "Bothergate";
            age = 234;
            writeProperties(bothFacade, name, age);
    
            // wait for user input.
            Console.ReadLine();
        }
    
        static void writeProperties(TestFacade facade, string name, int age)
        {
            Console.WriteLine("Person name: {0} Last Name: {1} Age : {2} ", name, facade.ITester.NamePlusLastName(name), facade.ITester.AgePlus20(age));
        }
    }
