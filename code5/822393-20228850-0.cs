        private void SaveObject<T>()
        {
            //Here the problem
            if (typeof(Employee).IsAssignableFrom(typeof(T)))
            {
                //Do something
            }
        }
