    var task = Task.Run(async () =>
                       {
                             try
                             {
                                    await AsyncHelper.DoSomethingAsync();
                             }
                             catch (Exception e)
                             {
                                   // Handle exception gracefully
                             }
                       });
