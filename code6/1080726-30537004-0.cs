            void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
            {
                var navigableViewModel = this.DataContext as INavigable;
                if (navigableViewModel != null)
                    navigableViewModel.BackButonPressed(e);
            }
