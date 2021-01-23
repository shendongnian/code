    string appLocation = System.IO.Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            string xslLocation = System.IO.Path.Combine(appLocation, @"SQL\fileName.sql");
            if (System.IO.File.Exists(xslLocation))
                MessageBox.Show("Exists");
            else
                MessageBox.Show("Not Exists");
