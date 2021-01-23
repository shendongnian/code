    server = mongoClient.GetServer();
            database = server.GetDatabase("facultyDataAndSchedule");
            collection = database.GetCollection<facultyData>("faculty");
            var query = collection.FindAllAs<facultyData>().SetFields(Fields.Include("facultyID", "term", "acadYear", "age", "program", "lastName", "firstName", "middleName", "dateOfBirth", "rank", "yearsOfTeachingS", "yearsOfTeachingO", "status", "services"));
            // List<facultyData> resultList = query.ToList<facultyData>();
           resultBinding = new ObservableCollection<facultyData>(query);
           facultyDataGrid.ItemsSource = resultBinding;
            try
            {
             
                try
                {
                    var entity = new facultyData
                    {
                        facultyID = facultyID_Textbox.Text.ToString(),
                        term = termComboBox.SelectedItem.ToString(),
                        age = int.Parse(age_TextBox.Text),
                        acadYear = "2014-2015",
                        firstName = firstName_TextBox.Text.ToString(),
                        lastName = lastName_TextBox.Text.ToString(),
                        middleName = middleName_TextBox.Text.ToString(),
                        dateOfBirth = dateOfBirth_TextBox.Text.ToString(),
                        program = "progra",
                        rank = "gegs",
                        services = "gegsg",
                        status = "geh",
                        yearsOfTeachingO = 1,
                        yearsOfTeachingS = 1
                    };
                    collection.Insert(entity);
                 
                    
                    
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            catch (MongoConnectionException ex)
            {
                Console.WriteLine(ex);
            }
            var query1 = collection.FindAllAs<facultyData>().SetFields(Fields.Include("facultyID", "term", "acadYear", "age", "program", "lastName", "firstName", "middleName", "dateOfBirth", "rank", "yearsOfTeachingS", "yearsOfTeachingO", "status", "services"));
            // List<facultyData> resultList = query.ToList<facultyData>();
            resultBinding = new ObservableCollection<facultyData>(query1);
            facultyDataGrid.ItemsSource = resultBinding;
        
