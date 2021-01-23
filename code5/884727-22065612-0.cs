            private void RibbonButton_Loaded(object sender, EventArgs e)
            {
            System.Windows.Controls.Ribbon.RibbonButton cmd = (System.Windows.Controls.Ribbon.RibbonButton)sender;
            if (EventLibrary.ContainsKey(cmd.Tag.ToString() + "_CLICKEVENT"))
            {
                List<RoutedEventHandler> value = EventLibrary[cmd.Tag.ToString() + "_CLICKEVENT"];
                for (int i = 0; i < value.Count; i++)
                {
                    cmd.AddHandler(RibbonButton.ClickEvent, value[i]);
                }
            }
            }
