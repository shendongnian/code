        this.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            //create a new label, and set it's content to a randomly generated number
                            Label lbl = new Label();
                            lbl.Content = DataSupplier.GenerateRandomInt();
        
                            //add this label to stackPanel1
                            stackPanel1.Children.Add(lbl);
                        }
                    }));
     Thread.Sleep(1000);
