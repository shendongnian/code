    // do stuff here                    
    Console.WriteLine("top");
    this.Dispatcher.BeginInvoke(new Action( () =>
    {
        // This runs on the UI thread
        BlueBan1_Image.Source = GUI.GetChampImageSource(JSONFile.Get("blue ban 1"), "avatar");
        Test_Button.Width = 500;
    }));
    Console.WriteLine("bottom");
