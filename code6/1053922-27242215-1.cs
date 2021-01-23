                if (linesCount > 0)
                {
                    linesCount++;
                    try
                    {
                        myTests.Add(new TestInfo(row));
                    }
                    catch (Exception ex)
                    {
                        // Create a log record or/and do something else to report the corrupted CSV line
                    }
                }
                linesCount++;
