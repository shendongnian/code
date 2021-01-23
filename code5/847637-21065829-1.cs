    private void AddTab(object sender, RoutedEventArgs e)
        {
            foreach (ClassFoo item in instanceBoo.methodBoo)
            {
                Type test = (Type) item.GetType();
                this.myViewModel.AvailableItems.Add(test);
            }
        }
