        public ActionResult Upload(HttpPostedFileBase File )
        {
            // Verify that the user selected a file
            if (File != null && File.ContentLength > 0)
            {
                StreamReader csvReader = new StreamReader(File.InputStream);
                {
                    string inputLine = "";
                    while ((inputLine = csvReader.ReadLine()) != null)
                    {
                        string[] values = inputLine.Split(new Char[] { ',' });
                        Movie movie = new Movie();
                        movie.Title = values[0];
                        movie.ReleaseDate = DateTime.Parse(values[1]);
                        movie.Genre = values[2];
                        movie.Price = Decimal.Parse(values[3]);
                        db.Movies.Add(movie);
                        db.SaveChanges();
                    }
                    csvReader.Close();
                  }
            }
           // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        } 
