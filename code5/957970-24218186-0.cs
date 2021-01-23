    var  newList = new List<string>();
    for (int index = 0; index < newText.Count; index = index + 3)
    {
        if (WordsList.words.Contains(newText[index]))
        {
            newList.AddRange(newText.Skip(index).Take(3));
        }
    }
    
    newText = newList; 
