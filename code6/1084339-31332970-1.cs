    // When you're attaching handlers
    int i=0;
    foreach (var child in buttonGrid.Children)
    {
        Button b = child as Button;
        if (b != null)
        {
            b.Click += () => {
                int z = i++; // You can put a different id generator here as well, like int z = <rand>%<prime> if you want
                DoSomething(z); // DoSomething called with corrosponding button id
            }
        }
    }
