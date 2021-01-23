    try
			{
                var container = new UnityContainer();
				schedulerFactory = CreateSchedulerFactory();
                quartzscheduler = GetScheduler();
			    SyncPost.Initialize.RepositoryConfig(container);
                SyncPost.Initialize.AddToSchedulerContextCustomVars(quartzscheduler, container);
                quartzscheduler.JobFactory = new JobFactoryInjection(container);
                
			}
			catch (Exception e)
			{
				logger.Error("Server initialization failed:" + e.Message, e);
				throw;
			}
