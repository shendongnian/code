    if (sorting != null)
                    {
                        if (sorting.Equals("TrackID ASC"))
                        {
                           daa = daa.OrderBy(p => p.TrackID);
                        }
                        else if (sorting.Equals("TrackID DESC"))
                        {
                          daa =  daa.OrderByDescending(p => p.TrackID);
                        }
                        if (sorting.Equals("TrackName ASC"))
                        {
                         daa =   daa.OrderBy(p => p.TrackName);
                        }
                        else if (sorting.Equals("TrackName DESC"))
                        {
                          daa =  daa.OrderByDescending(p => p.TrackName);
                        }
                        else if (sorting.Equals("DateTimes ASC"))
                        {
                           daa = daa.OrderBy(p => p.Date);
                        }
                        else if (sorting.Equals("DateTimes DESC"))
                        {
                          daa =  daa.OrderByDescending(p => p.Date);
                        }
                        else if (sorting.Equals("ArtistName ASC"))
                        {
                            daa.OrderBy(p => p.ArtistName);
                        }
                        else if (sorting.Equals("ArtistName DESC"))
                        {
                          daa =  daa.OrderByDescending(p => p.ArtistName);
                        }
                        else if (sorting.Equals("Times ASC"))
                        {
                          daa =  daa.OrderBy(p => p.Times);
                        }
                        else if (sorting.Equals("Times DESC"))
                        {
                          daa =  daa.OrderByDescending(p => p.Times);
                        }
                    }
