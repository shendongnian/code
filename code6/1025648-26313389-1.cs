    private async void btn_loginAdmin_Click(object sender, RoutedEventArgs e)
            {
                // 'txt_adminId' does not exist in the current context.
    
                if (txt_adminId.Text == "root")
                {
                    // 'txt_adminPw' does not exist in the current context.
                    if (txt_adminPw.Password == "password")
                    {
                        var msg_login = new MessageDialog("Logged in!");
                        await msg_login.ShowAsync();
                    }
                    else
                    {
                        var msg_login = new MessageDialog("Wrong password!");
                        await msg_login.ShowAsync();
                    }
                }
                else
                {
                    var msg_login = new MessageDialog("Wrong combo!");
                    await msg_login.ShowAsync();
                }
            }
