    List<List<string>> mainList = new List<List<string>>();
    int listIndex = 0;
    string[] fileData = File.ReadAllText(@" To-Do References.txt").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
    for(int i = 0; i<=fileData.Length; i++)
    {
        mainList[listIndex].Add(fileData[i]);
        if (i%10 == 0)
        {
            listIndex++;
        }
    }
