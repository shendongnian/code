    int limit = 10;
    int checkList = 1;
    string[] fileData = File.ReadAllText(@" To-Do References .txt").Split(new string[] { "\r\n" },    StringSplitOptions.RemoveEmptyEntries);
    
    for (int i = 0; i < fileData.Length; i++)
    {
        if (i == limit * checkList)
        {
            checkList++;
        }
        switch (checkList)
        {
            case 1: checkedListBox1.Items.Add(fileData[i]); break;
            case 2: checkedListBox2.Items.Add(fileData[i]); break;
            case 3: checkedListBox3.Items.Add(fileData[i]); break;
        }
    }
