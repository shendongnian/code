    // test
        static void Main(string[] args)
        {
            MyXmlReader reader = new MyXmlReader();
            DataElement data = reader.Load("Data.xml");
            // Generic test:
            // get first module
            data = reader.GetNext(data.SubTitles[0]);
            // get first function 
            data = reader.GetNext(data.SubTitles[0]);
            // get first sub-function 
            data = reader.GetNext(data.SubTitles[0]);         
            // you can write test with hardcode nodes names like this:
            reader.Init();
            // get first module
            data = reader.GetNext("Mod1");
            // get first function 
            data = reader.GetNext("Fun1");
            // get first sub-function 
            data = reader.GetNext("SubFun1");  
            Console.Read();
        }
