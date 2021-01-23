    public async Task<bool> GetPersons()
    {
        try
        {
            var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.db3");
    
            //Initialize the PersonList, so PersonList won't be null.
            PersonList = new PersonCollection();
            using (var db = new SQLite.SQLiteConnection(dbPath))
            {
                var listadepersonas = from x in db.Table<Person>() select x;
                foreach (var persona in listadepersonas)
                {
                    PersonList.Add(new Person()
                    {
                        id = persona.id,
                        Name = persona.LastName,
                        LastName = persona.LastName,
                        Celphone = persona.Celphone
                    });
                }
                db.Dispose();
                db.Close();
            }
    
            return true;
        }
        catch (Exception ex)
        {
            string sErr = ex.Message;
            return false;
        }
    }
