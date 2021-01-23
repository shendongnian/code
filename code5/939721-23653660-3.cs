        public string initialize(string test)
        {
            Thread update = new Thread(checkForUpdates);
            update.Start();
            form = test;
            return test;
        }
