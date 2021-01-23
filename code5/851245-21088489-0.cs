    #region Usings
    using System;
    using System.IO;
    
    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using log4net.Filter;
    using log4net.Layout;
    using log4net.Repository;
    using log4net.Repository.Hierarchy;
    
    
    #endregion
    
    
    namespace Common.Voyager
    {
    	/// <summary>
    	/// A static class that emulates defualt log4net LogManager static class.
    	/// The difference is that you can get various loggers istances based from an args.
    	/// LogMaster will create a different logger repository for each new arg it will receive.
    	/// </summary>
    	public static class LogMaster
    	{
    		#region Const
    		private const string RollingFileAppenderNameDefault = "Rolling";
    		private const string MemoryAppenderNameDefault = "Memory";
    		#endregion
    
    
    		#region Constructors
    		static LogMaster()
    		{
    		}
    		#endregion
    
    
    		#region Public Methods
    		public static ILog GetLogger(string arg, string name)
    		{
    			//It will create a repository for each different arg it will receive
    			var repositoryName = arg;
    
    			ILoggerRepository repository = null;
    			
    			var repositories = LogManager.GetAllRepositories();
    			foreach (var loggerRepository in repositories)
    			{
    				if (loggerRepository.Name.Equals(repositoryName))
    				{
    					repository = loggerRepository;
    					break;
    				}
    			}
    			
    			Hierarchy hierarchy = null;
    			if (repository == null)
    			{
    				//Create a new repository
    				repository = LogManager.CreateRepository(repositoryName);
    
    				hierarchy = (Hierarchy)repository;
    				hierarchy.Root.Additivity = false;
    
    				//Add appenders you need: here I need a rolling file and a memoryappender
    				var rollingAppender = GetRollingAppender(repositoryName);
    				hierarchy.Root.AddAppender(rollingAppender);
    
    				var memoryAppender = GetMemoryAppender(repositoryName);
    				hierarchy.Root.AddAppender(memoryAppender);
    
    				BasicConfigurator.Configure(repository);
    			}
    
    			//Returns a logger from a particular repository;
    			//Logger with same name but different repository will log using different appenders
    			return LogManager.GetLogger(repositoryName, name);
    		}
    		#endregion
    
    
    		#region Private Methods
    		private static IAppender GetRollingAppender(string arg)
    		{
    			var level = Level.All;
    
    			var rollingFileAppenderLayout = new PatternLayout("%date{HH:mm:ss,fff}|T%2thread|%25.25logger|%5.5level| %message%newline");
    			rollingFileAppenderLayout.ActivateOptions();
    
    			var rollingFileAppenderName = string.Format("{0}{1}", RollingFileAppenderNameDefault, arg);
    	
    			var rollingFileAppender = new RollingFileAppender();
    			rollingFileAppender.Name = rollingFileAppenderName;
    			rollingFileAppender.Threshold = level;
    			rollingFileAppender.CountDirection = 0;
    			rollingFileAppender.AppendToFile = true;
    			rollingFileAppender.LockingModel = new FileAppender.MinimalLock();
    			rollingFileAppender.StaticLogFileName = true;
    			rollingFileAppender.RollingStyle = RollingFileAppender.RollingMode.Date;
    			rollingFileAppender.DatePattern = ".yyyy-MM-dd'.log'";
    			rollingFileAppender.Layout = rollingFileAppenderLayout;
    			rollingFileAppender.File = string.Format("{0}.{1}", "log", arg);
    			rollingFileAppender.ActivateOptions();
    
    			return rollingFileAppender;
    		}
    
    		private static IAppender GetMemoryAppender(string station)
    		{
    			//MemoryAppender
    			var memoryAppenderLayout = new PatternLayout("%date{HH:MM:ss} | %message%newline");
    			memoryAppenderLayout.ActivateOptions();
    
    			var memoryAppenderWithEventsName = string.Format("{0}{1}", MemoryAppenderNameDefault, station);
    			var levelRangeFilter = new LevelRangeFilter();
    			levelRangeFilter.LevelMax = Level.Fatal;
    			levelRangeFilter.LevelMin = Level.Info;
    
    			var memoryAppenderWithEvents = new MemoryAppenderWithEvents();
    			memoryAppenderWithEvents.Name = memoryAppenderWithEventsName;
    			memoryAppenderWithEvents.AddFilter(levelRangeFilter);
    			memoryAppenderWithEvents.Layout = memoryAppenderLayout;
    			memoryAppenderWithEvents.ActivateOptions();
    
    			return memoryAppenderWithEvents;
    		}
    		#endregion
    	}
    }
