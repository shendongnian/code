    int iID = 1;
            XNamespace xn = "http://www.imdb.co.uk";
            // List of individual directors;
            var list = xeDir.Descendants(xn + "DirectorMovie").Select(item => new Director()
                                                        {
                                                            DirectorID = iID++,
                                                            Name = item.Element(xn + "Director").Element(xn + "Name").Value
                                                        });
            // Dictionary of directors name vs movies list.
            var movList = xeDir.Descendants(xn + "DirectorMovie").
                ToDictionary(dir => dir.Element(xn + "Director").Element(xn + "Name").Value,
                                              dir => dir.Elements(xn + "Movie").
                                                  Select(mov => new Movie()
                                              {
                                                  Genre = mov.Element(xn + "Genre").Value,
                                                  MovieName = mov.Element(xn + "MovieName").Value,
                                                  Rating = mov.Element(xn + "Rating").Value,
                                                  DirectorID = list.Where(item => item.Name == dir.Element(xn + "Director").Element(xn + "Name").Value).First().DirectorID.ToString()
                                                  
                                              })
                             );
