    string str = "[[1,2,3,4],sample,test:[abc,acd,12],1000]";
    string remove = Regex.Replace(str, @"]$|^\[", "");
      
    string[] lines = Regex.Split(remove, @",(?![^\[\]]*\])");
     
    foreach (string line in lines) {
    Console.WriteLine(line);
    }
      Console.ReadLine();
    }
