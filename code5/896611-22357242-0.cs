    using System;
    using Antmicro.Migrant;
    using System.Diagnostics;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System.Windows;
    
    namespace test15
    {
	class MainClass
	{
		private static void EnsureEqual(Point[] source, Point[] result)
		{
			for (var i = 0; i < result.Length; ++i) {
				if (source [i] != result [i]) {
					throw new Exception ();
				}
			}
		}
		public static void Main (string[] args)
		{
			var source = new Point[1000000];
			Point[] result, binResult;
			var timer = new Stopwatch ();
			for (var i = 0; i < source.Length; ++i) {
				source [i] = new Point (i, i);
			}
			//Migrant
			timer.Start ();
			result = Serializer.DeepClone (source);
			timer.Stop ();
			EnsureEqual (source, result);
			Console.WriteLine ("Migrant time: {0}", timer.Elapsed);
			timer.Reset ();
			//Binary formatter
			var binaryForm = new BinaryFormatter ();
			using (var ms = new MemoryStream ()) {
				timer.Start ();
				binaryForm.Serialize (ms, source);
				ms.Position = 0;
				binResult = binaryForm.Deserialize(ms) as Point[];
				timer.Stop ();
			}
			Console.WriteLine ("Binary formatter time: {0}", timer.Elapsed);
			EnsureEqual (source, binResult);
		}
	}
    }
