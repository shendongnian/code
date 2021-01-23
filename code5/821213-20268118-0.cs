        public static RelayCommand NavigateTo<T>()
        {
            Type dest = typeof(T);
            var relayCmd = new RelayCommand(() => Navigate(dest));
            return relayCmd;
        }
        private static void Navigate(object navigateTo)
        {
            Type dest = navigateTo.GetType();
            var newWin = Activator.CreateInstance(dest);
            ((Window)newWin).Show();
        }
