            listuser.AsParallel().Where(
                s =>
                {
                    foreach (var key in key_blacklist)
                    {
                        if (s.Contains(key))
                        {
                            return false; //Not to be included
                        }
                    }
                    return true; //To be included, as no match with the blacklist
                });
