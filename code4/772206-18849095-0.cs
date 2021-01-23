    var w = new Word(2, 3, "age", 1)
    
    var mention1 = new Mention(w);
    var mention2 = new Mention(w);
    
    mention1.UpdateWord(); // sets the fourth property of w to 3
    
    mention2.PrintWord(); // prints (2, 3, "age", 3)
