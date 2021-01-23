            ObservableCollection<Person> obsPerson = new ObservableCollection<Person>();
            //Storage
            IsolatedStorageSettings.ApplicationSettings["obsPerson"] = obsPerson;
            //Retrieval
            if (IsolatedStorageSettings.ApplicationSettings.Contains("obsPerson"))
            {
                ObservableCollection<Person> obsPerson = (ObservableCollection<person>)IsolatedStorageSettings.ApplicationSettings["obsPerson"];
            }
