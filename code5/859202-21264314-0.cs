    //you need some variable to save the next Top for each new button:
    //let's call it nextTop:
    int nextTop = 0;
    foreach (FileInfo file in d.GetFiles("*.*"))
    {
        Button button = new Button { Top = nextTop,      
                                     Text = file.Name };
        button.Click += new EventHandler(button_Click);
        page.Controls.Add(button);
        nextTop += button.Height + 5; //it's up to you on the 
                                     //Height and vertical spacing
    }
    //...
