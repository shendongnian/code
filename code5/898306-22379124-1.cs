    UIServicemock.Setup(
                        u =>
                        u.ShowDialog(It.IsAny<string>(), 
                                     It.IsAny<string>(), 
                                     It.IsAny<Dictionary<string, object>>(), 
                                     It.IsAny<Action<Dictionary<string, object>>>(), 
                                     It.IsAny<Dictionary<string, object>>()))
                 .Callback<string, 
                           string, 
                           Dictionary<string, object>, 
                           Action<Dictionary<string, object>>, 
                           Dictionary<string, object>>(
                                                       (windowName, 
                                                        parentWindowName, 
                                                        inputFields, 
                                                        closeCallBack, 
                                                        windowProperties) =>
                           closeCallBack(windowProperties /* or whatever dictionary should go here*/)
                                                        );
