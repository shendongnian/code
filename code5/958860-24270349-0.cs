	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using MonoTouch.Foundation;
	using MonoTouch.UIKit;
	using SQLite;
	namespace SO24247435
	{
		public class URMMobileAccount
		{
			[PrimaryKey, AutoIncrement]
			public int URMID {get;set;}
			public int Id {get; set;}
			public string Username {get; set;}
			public string Password {get; set;}
			public string Type {get; set;}
			public Nullable<int> TypeId {get; set;}
			public bool IsValid {get; set;}
		}
		[Register ("AppDelegate")]
		public class AppDelegate : UIApplicationDelegate
		{
			UIWindow window;
			public override bool FinishedLaunching (UIApplication app, NSDictionary options)
			{
				using (var db = new SQLiteConnection (
					Path.Combine(Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments),"test.sqlite"))) 
				{           
					try 
					{
						db.CreateTable<URMMobileAccount> ();
						var localAccount = db.Query<URMMobileAccount> ("Select * from URMMobileAccount");                                                      
						if (localAccount.Any ()) 
						{   
							Console.WriteLine (localAccount [0].Username);
						}      
					}
					catch (Exception ex) 
					{              
						Console.WriteLine (ex);
					}
				}
				window = new UIWindow (UIScreen.MainScreen.Bounds);
				// window.RootViewController = myViewController;
				window.MakeKeyAndVisible ();
				
				return true;
			}
			static void Main (string[] args)
			{
				UIApplication.Main (args, null, "AppDelegate");
			}
		}
	}
