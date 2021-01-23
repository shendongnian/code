    using JIS.Context;
	using JIS.Managers;
	using JIS.Models;
	using JIS.Services;
	using System;
	using System.Collections.Generic;
	using System.Web;
	using System.Web.Mvc;
	namespace JIS.Controllers
	{
		public class BaseController : Controller
		{
			public BaseController()
			{
				ViewBag.User = UserManager?.User;
			}
			private IUserManager userManager;
			public IUserManager UserManager
			{
				get
				{
					if (userManager == null)
					{
						userManager = DependencyResolver.Current.GetService<IUserManager>();
					}
					return userManager;
				}
				set
				{
					userManager = value;
				}
			}
			private ILoggingService loggingService;
			public ILoggingService LoggingService
			{
				get
				{
					if (loggingService == null)
					{
						loggingService = DependencyResolver.Current.GetService<ILoggingService>();
					}
					return loggingService;
				}
				set { loggingService = value; }
			}
			private IUserDirectory userDirectory;
			public IUserDirectory UserDirectory
			{
				get
				{
					if (userDirectory == null)
					{
						userDirectory = DependencyResolver.Current.GetService<IUserDirectory>();
					}
					return userDirectory;
				}
				set { userDirectory = value; }
			}
			private ApplicationDbContext appDb;
			public ApplicationDbContext AppDb
			{
				get
				{
					if (appDb == null)
					{
						appDb = new ApplicationDbContext();
					}
					return appDb;
				}
				set
				{
					appDb = value;
				}
			}
       
			protected override void Dispose(bool disposing)
			{
				if (disposing && appDb != null)
				{
					appDb.Dispose();
				}
				base.Dispose(disposing);
			}
		}
	}
