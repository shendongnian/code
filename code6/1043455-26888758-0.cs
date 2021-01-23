        public void NavigateToPage<T>()
        {
            var type = typeof(T);
            var testvalue = (type.FullName.Substring(type.FullName.IndexOf('.')).Replace('.', '/')) + ".xaml";
            RootFrame.Navigate(new Uri(testvalue, UriKind.Relative));
        }
