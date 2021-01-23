                IEnumerable<string> email = await App.MobileService.GetTable<register>()
                .Where(x => x.email == tbemail.Text && x.pwd == tbpswd.Password)
                .Select(x => x.email)
                .ToEnumerableAsync();
                m = email.FirstOrDefault();
                m1 = "login successful...";
                if (m != null)
                    this.Frame.Navigate(typeof(login2));
                else
                    m1 = "invalid user id or password...";
            }
            catch
            {
               
            }
            var dialog = new MessageDialog(m1);
            dialog.Commands.Add(new UICommand("OK"));
            await dialog.ShowAsync();
