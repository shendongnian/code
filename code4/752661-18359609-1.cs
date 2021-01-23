            await Task.Run(async () =>
            {
                // Some code that can throw an exception
                ...
            }).ContinueWith(async (a) =>
            {
                if (a.IsFaulted)
                {
                    var dialog = new MessageDialog("Something went wrong!\nError: "
                               + a.Exception.Message);
                    await dialog.ShowAsync();
                }
                else
                {
                    var dialog2 = new MessageDialog("Everything is OK: " + a.Result);
                    await dialog2.ShowAsync();
                }
            }).Unwrap();
