    // When you're attaching handlers
    int i=0;
    foreach (var child in buttonGrid.Children)
    {
        Button b = child as Button;
        if (b != null)
        {
            b.Click += () => {
                int z = i;
                DoSomething(z); // DoSomething called with corrosponding button id
            }
        }
        i++;
    }
