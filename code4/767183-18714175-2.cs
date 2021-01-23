    for (int i = 1; i <= 10; i++)
                                {
        lbl.Content = DataSupplier.GenerateRandomInt();
        this.Dispatcher.BeginInvoke((Action)(() =>
       {
    //create a new label, and set it's content to a randomly generated number
               Label lbl = new Label();  
        //add this label to stackPanel1
           stackPanel1.Children.Add(lbl);
                            }));
        Thread.Sleep(1000);
        }
