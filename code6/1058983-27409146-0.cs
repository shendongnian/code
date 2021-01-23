    string allowed = "abc";
    string read= Console.ReadLine();
    for (int i = 0; i < read.Length; i++ )
    {
       bool isValid = false;
       for (int j = 0; j < allowed.Length; j++) 
       {
          if (read[i] == allowed[j])
          {
             isValid = true;
             break;
          }
       }
       if (isValid)
       {
        Console.WriteLine("Okay");
       }else{
        Console.WriteLine("Invalid char on" +index);
       }
    }
