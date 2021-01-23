            var result = ListOfFiles.Select(_s =>
                {
                    try
                    {
                        return new ObjectA(_s);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    
                }).Where(x => x != null).ToList();
