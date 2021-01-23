   		public static void Main (string[] args)
		{
			Assess ("/opt",5, false);
			Console.WriteLine ("**********************");
			Assess ("/opt",5, true);
		}
		public static void Assess (string root,int iteration, bool net=true)
		{
			var watch = new Stopwatch ();
			var fCount = 0;
			var dCount = 0;
			watch.Start ();
			for (var i=0; i<iteration; i++) {
				if (net) {
					Console.WriteLine ("assessing .Net Bcl");
					var dirInfo = new System.IO.DirectoryInfo (root);
					AssessNet (dirInfo, ref fCount, ref dCount);
				} else {
					Console.WriteLine ("assessing Mono Posix");
					var unixDirInfo = new Mono.Unix.UnixDirectoryInfo (root);
					AssessMono (unixDirInfo, ref fCount, ref dCount);
				}
			}
			watch.Stop ();
			Console.WriteLine ("crawl time: {0} ms", watch.ElapsedMilliseconds);
			Console.WriteLine ("files count: {0}, directory count: {1}", fCount, dCount);
		}
		public static void AssessNet (System.IO.DirectoryInfo root, ref int fCount, ref int dCount)
		{
			var files = root.GetFiles ();
			var dirs = root.GetDirectories ();
			foreach (var f in files) {
				fCount++;
			}
			foreach (var d in dirs) {
				dCount++;
				AssessNet (d, ref fCount, ref dCount);
			}
		}
		public static void AssessMono (Mono.Unix.UnixDirectoryInfo root,ref int fCount,ref int dCount)
		{
			var entries = root.GetFileSystemEntries ();
			foreach (var e in entries) {
				if (e.IsDirectory) {
					dCount++;
					AssessMono (e as Mono.Unix.UnixDirectoryInfo,ref fCount,ref dCount);
				} else {
					fCount++;`enter code here`
				}
			}
		}
	}
