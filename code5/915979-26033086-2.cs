    private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Hello, world!");
            
    MessageDialog msgbox = new MessageDialog("Would you like to greet the world with a \"Hello, world\"?", "My App");
            
            msgbox.Commands.Clear();
            msgbox.Commands.Add(new UICommand { Label = "Yes", Id = 0 });
            msgbox.Commands.Add(new UICommand { Label = "No", Id = 1});
            msgbox.Commands.Add(new UICommand { Label = "Cancel", Id = 2 });
            
            var res = await msgbox.ShowAsync(); 
            if ((int)res.Id == 0)
            {
                MessageDialog msgbox2 = new MessageDialog("Hello to you too! :)", "User Response");
                await msgbox2.ShowAsync();
            }
            if ((int)res.Id == 1)
            {
                MessageDialog msgbox2 = new MessageDialog("Oh well, too bad! :(", "User Response");
                await msgbox2.ShowAsync();
            }
            if ((int)res.Id == 2)
            {
                MessageDialog msgbox2 = new MessageDialog("Nevermind then... :|", "User Response");
                await msgbox2.ShowAsync();
            }
                
        }
