            MessageBinder.SpecialValues.Add("$ischecked", context =>
            {
                var args = context.EventArgs as RoutedEventArgs;
                if (args == null) {
                    return null;
                }
                var fe = args.OriginalSource as MenuItem;
                if (fe == null) {
                    return null;
                }
                return fe.IsChecked;
            });
