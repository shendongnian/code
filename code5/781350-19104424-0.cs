    List<Label> myLabels = new List<Label>(txt);
    for (int i = 0; i < txt; i++)
    {
        newLabel = new Label();
        newLabel.MouseMove += MyControl_MouseMove;
        newLabel.MouseDown += MyControl_MouseDown;
        myLabels.Add(newLabel);
    .......
    
    // Later in Dispose
    foreach (var lbl in myLabels)
    {
         lbl -= MyControl_MouseMove;
         lbl -= MyControl_MouseDown;
    }
    myLabels.Clear();
