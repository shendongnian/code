        private void AddPersonOnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Persons.Add(new Person
            {
                Age = 55,
                Name = "Sand"
            });
        }
