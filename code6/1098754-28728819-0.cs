    //This code first read the words in text file one by one, 
    //which are save in nodepad file like one word per line 
    int aCounter = 0; string aWordInTextFile;
    // Read the file and display it line by line.
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\notePadFile.txt");
    while((aWordInTextFile = file.ReadLine()) != null){
       Console.WriteLine (aWordInTextFile);
       if(textbox.text == "aWordInTextFile"){
            printf("String Match, found a string in notepad file");
       }
       aCounter++;
       
    }
    
    file.Close();
    
    // Suspend the screen.
    Console.ReadLine();
 
