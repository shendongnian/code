    using Newtonsoft.Json;
    using Newtonsoft.Json.Bson;
    using NUnit.Framework;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Windows.Media.Media3D;
    
    namespace DemoPoint3DSerialize
    {
    	[TestFixture]
    	class Tests
    	{
    		[Test]
    		public void DemoBinary()
    		{
    			// this shows how to convert them all to strings
    			var collection = CreateCollection();
    			var data = collection.Select(c => c.ToArray()).ToList(); // switch to serializable types
    			var formatter = new BinaryFormatter();
    
    			using (var ms = new MemoryStream())
    			{
    				formatter.Serialize(ms, data);
    				Trace.WriteLine("Binary of Array Size: " + ms.Position);
    				ms.Position = 0;
    				var dupe = (List<Point3D[]>)formatter.Deserialize(ms);
    				var result = new ConcurrentBag<Point3DCollection>(dupe.Select(r => new Point3DCollection(r)));
    				VerifyEquality(collection, result);
    			}
    		}
    
    		[Test]
    		public void DemoString()
    		{
    			// this shows how to convert them all to strings
    			var collection = CreateCollection();
    			IEnumerable<IList<Point3D>> tmp = collection;
    			var strings = collection.Select(c => c.ToString()).ToList();
    
    			Trace.WriteLine("String Size: " + strings.Sum(s => s.Length)); // eh, 2x for Unicode
    			var result = new ConcurrentBag<Point3DCollection>(strings.Select(r => Point3DCollection.Parse(r)));
    
    			VerifyEquality(collection, result);
    		}
    
    		[Test]
    		public void DemoDeflateString()
    		{
    			// this shows how to convert them all to strings
    			var collection = CreateCollection();
    			var formatter = new BinaryFormatter(); // not really helping much: could 
    			var strings = collection.Select(c => c.ToString()).ToList();
    
    			using (var ms = new MemoryStream())
    			{
    				using (var def = new DeflateStream(ms, CompressionLevel.Optimal, true))
    				{
    					formatter.Serialize(def, strings);
    				}
    				Trace.WriteLine("Deflate Size: " + ms.Position);
    				ms.Position = 0;
    				using (var def = new DeflateStream(ms, CompressionMode.Decompress))
    				{
    					var stringsDupe = (IList<string>)formatter.Deserialize(def);
    					var result = new ConcurrentBag<Point3DCollection>(stringsDupe.Select(r => Point3DCollection.Parse(r)));
    
    					VerifyEquality(collection, result);
    				}
    			}
    		}
    
    		[Test]
    		public void DemoStraightJson()
    		{
    			// this uses Json.NET
    			var collection = CreateCollection();
    			var formatter = new JsonSerializer();
    
    			using (var ms = new MemoryStream())
    			{
    				using (var stream = new StreamWriter(ms, new UTF8Encoding(true), 2048, true))
    				using (var writer = new JsonTextWriter(stream))
    				{
    					formatter.Serialize(writer, collection);
    				}
    				Trace.WriteLine("JSON Size: " + ms.Position);
    				ms.Position = 0;
    				using (var stream = new StreamReader(ms))
    				using (var reader = new JsonTextReader(stream))
    				{
    					var result = formatter.Deserialize<List<Point3DCollection>>(reader);
    					VerifyEquality(collection, new ConcurrentBag<Point3DCollection>(result));
    				}
    			}
    		}
    
    		[Test]
    		public void DemoBsonOfArray()
    		{
    			// this uses Json.NET
    			var collection = CreateCollection();
    			var formatter = new JsonSerializer();
    
    			using (var ms = new MemoryStream())
    			{
    				using (var stream = new BinaryWriter(ms, new UTF8Encoding(true), true))
    				using (var writer = new BsonWriter(stream))
    				{
    					formatter.Serialize(writer, collection);
    				}
    				Trace.WriteLine("BSON Size: " + ms.Position);
    				ms.Position = 0;
    				using (var stream = new BinaryReader(ms))
    				using (var reader = new BsonReader(stream, true, DateTimeKind.Unspecified))
    				{
    					var result = formatter.Deserialize<List<Point3DCollection>>(reader); // doesn't seem to read out that concurrentBag
    					VerifyEquality(collection, new ConcurrentBag<Point3DCollection>(result));
    				}
    			}
    		}
    
    		private ConcurrentBag<Point3DCollection> CreateCollection()
    		{
    			var rand = new Random(42);
    			var bag = new ConcurrentBag<Point3DCollection>();
    
    			for (int i = 0; i < 10; i++)
    			{
    				var collection = new Point3DCollection();
    				for (int j = 0; j < i + 10; j++)
    				{
    					var point = new Point3D(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
    					collection.Add(point);
    				}
    				bag.Add(collection);
    			}
    			return bag;
    		}
    
    		private class CollectionComparer : IEqualityComparer<Point3DCollection>
    		{
    			public bool Equals(Point3DCollection x, Point3DCollection y)
    			{
    				return x.SequenceEqual(y);
    			}
    
    			public int GetHashCode(Point3DCollection obj)
    			{
    				return obj.GetHashCode();
    			}
    		}
    
    		private void VerifyEquality(ConcurrentBag<Point3DCollection> collection, ConcurrentBag<Point3DCollection> result)
    		{
    			var first = collection.OrderBy(c => c.Count);
    			var second = collection.OrderBy(c => c.Count);
    			first.SequenceEqual(second, new CollectionComparer());
    		}
    
    
    	}
    }
