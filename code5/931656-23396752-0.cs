	using System;
	using ServiceStack;
	using System.Collections.Generic;
	namespace v4
	{
		class MainClass
		{
			// Assumed implementation of your getByteArrayFromString
			static byte[] getByteArrayFromString(string path)
			{
				return System.IO.File.ReadAllBytes(path);
			}
			public static void Main()
			{
				// Simple Self-Hosted Console App
				var appHost = new AppHost(500);
				appHost.Init();
				appHost.Start("http://*:9000/");
				// Test the service
				string filename = "image.png";
				JsonServiceClient client  = new JsonServiceClient("http://localhost:9000");
				// Create and set the file contents
				UserFile file = new UserFile (filename, "username");
				file.SetFileContent(getByteArrayFromString(filename), 0);
				// Post the file
				client.Post<Object>("/updatefile", new UpdateFile { file = file } );
				Console.ReadKey();
			}
		}
		public class AppHost : AppHostHttpListenerPoolBase
		{
			public AppHost(int poolSize) : base("Test Service", poolSize, typeof(TestService).Assembly) { }
			public override void Configure(Funq.Container container) { }
		}
				
		[Route("/updatefile","POST")]
		public class UpdateFile
		{
			public UserFile file { get; set; }
		}
		[Serializable]
		public class UserFile 
		{
			public string filepath { get; set;}
			public string owner { get; set;}
			public byte[] filecontent { get; set;}
			public long filesize { get; set;}
			public List<string> sharedwithclients { get; set;}
			public long versionNumber {get;set;}
			object privateLock = new object();
			public UserFile (string filepath, string owner)
			{      
				this.filepath = filepath;
				this.owner = owner;
				versionNumber = -1;
				filesize = 0;
				filecontent = new byte[0];
				sharedwithclients = new List<string>();
			}
			public void SetFileContent(byte[] contents, long version)
			{
				filecontent = contents;
				filesize = filecontent.Length;
				versionNumber = version;
			}
		}
		public class TestService : Service
		{
			public void Post(UpdateFile request)
			{
				// Request is populated correctly i.e. not null.
				Console.WriteLine(request.file.ToJson());
			}
		}
	}
