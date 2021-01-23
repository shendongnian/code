    TextBox soora = new TextBox();
                    soora.Height = 72;
                    soora.Width = 150;
                    soora.MaxLength = 3;
    
    TextBox ayath = new TextBox();
                    ayath.Height = 72;
                    ayath.Width = 150;
                    ayath.MaxLength = 3;
    
    StackPanel container = new StackPanel{
                               Orientation = System.Windows.Controls.Orientation.Horizontal
                           };
    
    container.Children.Add(soora);
    container.Children.Add(ayath);    
    
    CustomMessageBox messageBox = new CustomMessageBox()
                {
                    Title = "GO TO",
                    Content = container,
                    RightButtonContent = "Go !",
                };
