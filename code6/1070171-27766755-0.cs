    var messgeDialog = new MessageDialog("Are you sure you want to close", "Are you sure?");
                        messgeDialog.Commands.Add(new UICommand("Yes"));
                        messgeDialog.Commands.Add(new UICommand("No"));
                        messgeDialog.DefaultCommandIndex = 0;
                        messgeDialog.CancelCommandIndex = 1;
                        var result = await messgeDialog.ShowAsync();
                        if (result.Label.Equals("Yes"))
                        {
                        //Do something when a user pressed yes
                        }
                        else
                        {
                        //User pressed no
                        }
