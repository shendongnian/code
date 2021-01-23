    string str = "<tag tsdfg> some other random text";
    string newStr = new string(str.TakeWhile(c => !Char.IsWhiteSpace(c))
                                  .Concat(str.SkipWhile(c => c != '>'))
                                  .ToArray());
    Console.WriteLine(newStr);  //  "<tag> some other random text" 
