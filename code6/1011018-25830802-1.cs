    string newWord = "your new word";
    string textFile = System.IO.File.ReadAllText("text file full path");
    if (!textFile.Contains(newWord))
    { 
        textFile = textFile + newWord;
        System.IO.File.WriteAllText("text file full path",textFile);
    }
