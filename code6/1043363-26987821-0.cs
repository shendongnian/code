      XmlSerializer serializer = new
                        XmlSerializer(typeof(Ratings));
                        XDocument document = XDocument.Load(isoStream);
                        Ratings ratings = (Ratings)serializer.Deserialize(document.CreateReader());
                        var result = ratings.Collection.Where(c => c.businessID == businessID);
                        if (result == null) return;
                        double db = 0.0;
                        ficounter.Text = result.Where(c => c.ratings == 5).Select(c => c.counter).SingleOrDefault();
                        if (double.TryParse(ficounter.Text, out db))
                            fiprogress.Value = db;
                        focounter.Text = result.Where(c => c.ratings == 4).Select(c => c.counter).SingleOrDefault();
                        if (double.TryParse(focounter.Text, out db))
                            foprogress.Value = db;
                        thcounter.Text = result.Where(c => c.ratings == 3).Select(c => c.counter).SingleOrDefault();
                        if (double.TryParse(thcounter.Text, out db))
                            thprogress.Value = db;
                        twcounter.Text = result.Where(c => c.ratings == 2).Select(c => c.counter).SingleOrDefault();
                        if (double.TryParse(twcounter.Text, out db))
                            twprogress.Value = db;
                        oncounter.Text = result.Where(c => c.ratings == 1).Select(c => c.counter).SingleOrDefault();
                        if (double.TryParse(oncounter.Text, out db))
                            onprogress.Value = db;
