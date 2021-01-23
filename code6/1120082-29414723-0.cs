            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                var dte = Package.GetGlobalService(typeof(DTE)) as DTE;
                if (dte == null) return;
                var window = dte.Windows.Item("{WindowGUID}");
                window.Visible = true;
            }
