     private RelayCommand __myListBox_DataContextChangedCommand;
            public RelayCommand MyListBox_DataContextChangedCommand
            {
                get
                {
                    return __myListBox_DataContextChangedCommand
                        ?? (__myListBox_DataContextChangedCommand = new RelayCommand(
                        () =>
                        {
                            //Your Event's Handler Goes Here
                        }));
                }
            }
