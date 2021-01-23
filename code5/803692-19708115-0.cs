    int index = 0;
    int number = 0;
    for(int i; i<ExampleList.Count; i++)
    {
        number = 0;
        StackPanel sp = FindElementInVisualTree<StackPanel>(LLMS, index);
        sp.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(StackPanel_Tap);
        index++;
    }
