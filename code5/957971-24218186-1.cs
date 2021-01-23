    var  newList = new List<string>();
    for (int index = 0; index < newText.Count; index = index + 3)
    {
        if (WordsList.words.Select(t => t.ToLower().Trim()).Contains(newText[index].ToLower().Trim()))
        {
            newList.AddRange(newText.Skip(index).Take(3));
        }
    }
    
    newText = newList; 
