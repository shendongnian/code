    if (sorting != null)
                    {
                        if (sorting.Equals("TrackID ASC"))
                        {
                           daa = daa.OrderBy(p => p.TrackID).ToList();
                        }
                        else if (sorting.Equals("TrackID DESC"))
                        {
                          daa =  daa.OrderByDescending(p => p.TrackID).ToList();
                        }
                        if (sorting.Equals("TrackName ASC"))
                        {
                         daa =   daa.OrderBy(p => p.TrackName).ToList();
                        }
                        else if (sorting.Equals("TrackName DESC"))
                        {
                          daa =  daa.OrderByDescending(p => p.TrackName).ToList();
                        }
                        else if (sorting.Equals("DateTimes ASC"))
                        {
                           daa = daa.OrderBy(p => p.Date).ToList();
                        }
                        else if (sorting.Equals("DateTimes DESC"))
                        {
                          daa =  daa.OrderByDescending(p => p.Date).ToList();
                        }
                        else if (sorting.Equals("ArtistName ASC"))
                        {
                           daa = daa.OrderBy(p => p.ArtistName).ToList();
                        }
                        else if (sorting.Equals("ArtistName DESC"))
                        {
                          daa =  daa.OrderByDescending(p => p.ArtistName).ToList();
                        }
                        else if (sorting.Equals("Times ASC"))
                        {
                          daa =  daa.OrderBy(p => p.Times).ToList();
                        }
                        else if (sorting.Equals("Times DESC"))
                        {
                          daa =  daa.OrderByDescending(p => p.Times).ToList();
                        }
                    }
