     firstStrings.ForEach(first => secondStrings.ForEach(second =>
                    {
                        try
                        {
                            if (second.Contains(DoFormatting(first)))
                            {
                                DoStuff(first, second);
                            }
                        }
                        catch(Exception e)
                        {
                            LogStuff(first, second);
                        }
                    }));
