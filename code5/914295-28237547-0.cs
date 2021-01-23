    private void HardwareButtonsOnBackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
                var dlg = new MessageDialog("Are you shure you want to quit?", "Exit application?");
                dlg.Commands.Add(new UICommand("Yes", c =>
                {
                    Application.Current.Exit();
                }));
                dlg.Commands.Add(new UICommand("No"));
                dlg.ShowAsync();
            }
        }
