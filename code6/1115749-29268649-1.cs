    `public void EightButton()
    {
        TheList.Clear();
        MyInternalGrid.RowDefinitions.Clear();
        for (int i = 0; i < 8; i++)
        {
            Button newBtn = new Button();
            newBtn.Content = i.ToString();
            newBtn.Name = "Button" + i.ToString();
            Grid.SetRow(newBtn, MyInternalGrid.RowDefinitions.Count);                
            MyInternalGrid.RowDefinitions.Add(new RowDefinition{Height=20});
            TheList.Add(newBtn);
        }
    }`
