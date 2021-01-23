        string selectedOption;
        do {
            Write();
            string name = Console.ReadLine();
            Write();
            string name1 = Console.ReadLine();
            Write();
            string name2 = Console.ReadLine();
            Write();
            string name3 = Console.ReadLine();
             Console.WriteLine("{0}, {1}, {2}, {3}",name,name1,name2,name3);
             Console.WriteLine("enter \"y\" to restart the program and \"n\" to exit the Program");
             selectedOption = Console.ReadLine();
          } while (selectedOption == "y")
          Console.ReadKey();
