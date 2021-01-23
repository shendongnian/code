    var  newList = new List<string>();
    for (int index = 0; index < newText.Count; index = index + 3)
    {
        if (WordsList.Any(t => newText[index].ToLower().Trim().Contains(t.ToLower().Trim())))
        {
            newList.AddRange(newText.Skip(index).Take(3));
        }
    }
    
    newText = newList; 
