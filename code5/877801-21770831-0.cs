		public static void SetPathTest()
		{
			using (var manager = new ServerManager())
			{
				const string Url = "mylocalsite.hereiam.com";
				var targsite = manager.Sites[Url];
				var targapp = targsite.Applications["/" + Url];
				var worked = false;
				Console.WriteLine("App path: {0}", targapp.Path);
				try
				{
					targapp.Path = @"C:\Projects\Demos\OData\Station.ODataNew";
					Console.WriteLine("Setting Path using Path worked!");
					worked = true;
				}
				catch (Exception)
				{
					Console.WriteLine("Oops. Path isn't settable this way");
				}
				if (!worked)
				{
					try
					{
						targapp.VirtualDirectories["/"].PhysicalPath = @"C:\Projects\Demos\OData\Station.ODataNew";
						Console.WriteLine("Setting path using the Virtual directory worked!");
					}
					catch (Exception)
					{
						Console.WriteLine("Oops. Virtual directory PhysicalPath isn't settable this way");
					}
				}
				manager.CommitChanges();
			}
		}
