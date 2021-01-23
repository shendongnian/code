    dt.AsEnumerable().Where(dr => 
                            {
                                var wordsSplited = dr.Field<string>("Column").Split(' ');
                                var words = new HashSet<string>(wordsSplited);
                                
                                var inputSplitted = str.Split(' ');
                                return words.Intersect(inputSplitted).Any();
                            });
