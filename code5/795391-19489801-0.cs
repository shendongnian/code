    //As you can imagine this won't work:
    foreach (DictionaryEntry vari in variables) {
        object v2 = vari;
        Console.WriteLine(v2.Key);
        Console.WriteLine(v2.Value); 
    }
    //This works!:
    foreach (var vari in variables) {
        DictionaryEntry v2 = (DictionaryEntry) vari;
        Console.WriteLine(v2.Key);
        Console.WriteLine(v2.Value); 
    }
