	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using ProtoBuf;
	namespace Protobuf_Net
	{
		class Program
		{
			static void Main(string[] args)
			{
				MyMessage original = new MyMessage(42, "Bob");
				byte[] rawBytes = original.ProtoBufSerialize<MyMessage>();
				MyMessage deserialized = rawBytes.ProtoBufDeserialize<MyMessage>();
				Console.WriteLine("Num={0}", deserialized.Num);
				Console.WriteLine("Name={0}", deserialized.Name);
				Console.Write("[any key]");
				Console.ReadKey();
			}
		}
	}
	public static class ProtoBufExtensions
	{
        // Intent: serializes any class to a byte[] array.
		public static byte[] ProtoBufSerialize<T>(this T message)
		{
			byte[] result;
			using (var stream = new MemoryStream())
			{
				Serializer.Serialize(stream, message);
				result = stream.ToArray();
			}
			return result;
		}
        // Intent: deserializes any class from a byte[] array.
		public static T ProtoBufDeserialize<T>(this byte[] bytes)
		{
			T result;
			using (var stream = new MemoryStream(bytes))
			{
				result = Serializer.Deserialize<T>(stream);
			}
			return result;
		}
	}
	[ProtoContract]
	public struct MyMessage
	{
	public MyMessage(int num, string name)
	{
		Num = num;
		Name = name;
	}
	[ProtoMember(1)]
	public int Num { get; set; }
	[ProtoMember(2)]
	public string Name { get; set; }
	}
