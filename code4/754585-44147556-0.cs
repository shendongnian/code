    try
                    {
                        base.OnLoad(e);
                    }
                    catch (ArgumentException e1)
                    {
                        Console.WriteLine(e1.StackTrace);
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1.StackTrace);
                    }
