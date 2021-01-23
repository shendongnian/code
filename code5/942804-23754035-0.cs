    for(int i = 0; i < 5; i++)
    {
        Button button = new Button();
        button.Name = String.Format("button{0}", i); // use better names
        // subscribe to Click event otherwise button is useless
        Controls.Add(button); // add to form's controls
    }
