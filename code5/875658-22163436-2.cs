        DataTable table = new DataTable(); 
        table.Columns.Add("Sex"); 
        table.Columns.Add("Height", typeof(double)); 
        table.Columns.Add("Weight", typeof(double)); 
        table.Columns.Add("FootSize", typeof(double)); 
        //training data. 
        table.Rows.Add("male", 6, 180, 12); 
        table.Rows.Add("male", 5.92, 190, 11); 
        table.Rows.Add("male", 5.58, 170, 12); 
        table.Rows.Add("male", 5.92, 165, 10); 
        table.Rows.Add("female", 5, 100, 6); 
        table.Rows.Add("female", 5.5, 150, 8); 
        table.Rows.Add("female", 5.42, 130, 7); 
        table.Rows.Add("female", 5.75, 150, 9); 
        table.Rows.Add("transgender", 4, 200, 5); 
        table.Rows.Add("transgender", 4.10, 150, 8); 
        table.Rows.Add("transgender", 5.42, 190, 7); 
        table.Rows.Add("transgender", 5.50, 150, 9);
        Classifier classifier = new Classifier(); 
        classifier.TrainClassifier(table);
        //output would be transgender.
        Console.WriteLine(classifier.Classify(new double[] { 4, 150, 12 }));
        Console.Read();
