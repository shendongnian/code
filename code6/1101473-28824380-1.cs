     String test = "1.23.4.34"; // test string
    
     String[] splits = test.Split('.'); // split by .
    
     splits[splits.Length - 1] = (int.Parse(splits[splits.Length - 1])+1).ToString(); // Increment last integer (Note : Assume all are integers)
    
     String answ = String.Join(".",splits); // Use string join to make the string from string array. uses . separator 
    
     Console.WriteLine(answ); // Answer  : 1.23.4.35
