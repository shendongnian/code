    var countMinusOne = myList.Count - 1;
    for(int i = 0; i < countMinusOne; i++)
        if(myList[i] != null)
            Assembler.AppendLine("(" + bullet++ + ") " + myList[i]);
    Assembler.AppendLine(myList[countMinusOne]);
