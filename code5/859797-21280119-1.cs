    var returnString = new string (s.Reverse().SkipWhile(
                    c =>
                        {
                            var skipped = false;
                            if (c == '&' && !skipped)
                            {
                                skipped = true;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }).Reverse().ToArray());
