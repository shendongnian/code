    var messageBox = new CustomMessageBox {
            Caption = "Send",
            Message = "",
            Content =  CreateMessageBoxContent(c.T),
            LeftButtonContent = "Send",
            RightButtonContent = "Close"
        }; 
    private static object CreateMessageBoxContent(string t)
        {
            var stackPanel = new StackPanel();
            var P1Label = new TextBlock {Text = AppResources.P1Label};
            var P2Label = new TextBlock {Text = AppResources.P2Label};
            var P3Label = new TextBlock {Text = AppResources.P3Label};
            var P1 = new TextBox();
            var P2 = new TextBox();
            var P3 = new TextBox();
                if (t == "T2" || t == "T20")
                {
                    stackPanel.Children.Add(P1Label);
                    stackPanel.Children.Add(P1);
                }
                else if (t =="T20D" || t == "T21D")
                {
                    stackPanel.Children.Add(P1Label);
                    stackPanel.Children.Add(P1);
                    stackPanel.Children.Add(P3Label);
                    stackPanel.Children.Add(P3);
                }
                else if (t == "T3" || t == "T31")
                {
                    stackPanel.Children.Add(P1Label);
                    stackPanel.Children.Add(P1);
                    stackPanel.Children.Add(P2Label);
                    stackPanel.Children.Add(P2);
                    stackPanel.Children.Add(P3Label);
                    stackPanel.Children.Add(P3);
                }
            return stackPanel;            
        }
