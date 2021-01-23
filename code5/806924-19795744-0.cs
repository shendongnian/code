      List<string> Students = new List<string>() { "Test1", "Test2" };
      List<string> Manager = new List<string>(){"Test1","Test1","Test3"};
    
                var counter = Manager.Count(m => m == Students[0]);
                Console.WriteLine(counter);
                Console.ReadLine();
