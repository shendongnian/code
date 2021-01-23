    Client_General_Information newObject = new Client_General_Information ();
    
    int NumberOfLines = 70;
    
    //Make our array for each line
    string[] ListLines = new string[NumberOfLines];
    
    //Read the number of lines and put them in the array
     for (int i = 0; i < NumberOfLines; i++)
     {
           ListLines[i] = tr.ReadLine();
     }
     newObject.Name=ListLines[0];
     newObject.LastName=ListLines[1];
