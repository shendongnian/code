            var observableCollection_Department = new ObservableCollection<Department>();
            var observableCollection_Employee = new ObservableCollection<Employee>();
            var observableCollection_Boss = new ObservableCollection<Boss>();
            
            var observableCollection = new ObservableCollection<object>();
            foreach (var element in observableCollection_Department)
            {
                observableCollection.Add(element);
            }
            foreach (var element in observableCollection_Employee)
            {
                observableCollection.Add(element);
            }
            foreach (var element in observableCollection_Boss)
            {
                observableCollection.Add(element);
            }
