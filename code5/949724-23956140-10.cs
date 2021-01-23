                NameValueCollection config = (NameValueCollection)ConfigurationManager.GetSection("quartz");
                ISchedulerFactory factory = new StdSchedulerFactory(config);
                IScheduler sched = factory.GetScheduler();
                try
                {
                    sched.Clear();
					/* schedule some jobs through code */
                    sched.Start();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine(string.Empty);
                    Console.WriteLine("Press ENTER to Continue to Shut Down");
                    Console.WriteLine(string.Empty);
                    Console.ReadLine();
                }
                finally
                {
                    sched.Shutdown(false);
                }
                Console.Write("");
            }
            catch (Exception ex)
            {
                Exception exc = ex;
                while (null != exc)
                {
                    Console.WriteLine(exc.Message);
                    exc = exc.InnerException;
                }
            }
            finally
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
                Console.WriteLine("Press ENTER to Exit");
                Console.ReadLine();
            }
