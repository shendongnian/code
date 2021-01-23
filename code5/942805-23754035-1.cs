    for(int i = 0; i < 5; i++)
    {
        Button button = new Button();
        button.Name = String.Format("button{0}", i); // use better names
        // subscribe to Click event otherwise button is useless
        button.Click = Button_Click;
        Controls.Add(button); // add to form's controls
    }
