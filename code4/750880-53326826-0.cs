            try
            {
                List<LogEntry> logs = driver.Manage().Logs.GetLog(LogType.Browser).ToList();
                foreach (LogEntry log in logs)
                {
                    while(logs.Count > 0)
                    {
                        String logInfo = log.ToString();
                        if (log.Message.Contains("Failed to load resource: the server responded with a status of 404 (Not Found)"))
                        {
                            Assert.Fail();
                        }
                        else
                        {
                            Assert.Pass();
                        }
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
        }
