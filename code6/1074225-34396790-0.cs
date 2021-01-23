		public class TupleConverter : Newtonsoft.Json.JsonConverter
		{
			public override bool CanConvert(Type objectType)
			{
				return typeof(Tuple<string, bool>) == objectType;
			}
			public override object ReadJson(
				Newtonsoft.Json.JsonReader reader,
				Type objectType,
				object existingValue,
				Newtonsoft.Json.JsonSerializer serializer)
			{
				if (reader.TokenType == Newtonsoft.Json.JsonToken.Null)
					return null;
				var jObject = Newtonsoft.Json.Linq.JObject.Load(reader);
				var target = new Tuple<string, bool>(
					(string)jObject["Item1"], (bool)jObject["Item2"]);
				return target;
			}
			public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
			{
				serializer.Serialize(writer, value);
			}
		}
		public class TupleHolder
		{
			[Newtonsoft.Json.JsonConverter(typeof(TupleConverter))]
			public Tuple<string, bool> Tup { get; set; }
			public TupleHolder() { Tup = new Tuple<string, bool>("ZZZ", false); }
			public TupleHolder(string s, bool b) { Tup = new Tuple<string, bool>(s, b); }
		}
		[Test]
		public void Test()
		{
			var orig = new TupleHolder("what????", true);
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(orig);
			Assert.AreEqual("{\"Tup\":{\"Item1\":\"what????\",\"Item2\":true}}", json);
			var dupl = Newtonsoft.Json.JsonConvert.DeserializeObject<TupleHolder>(json);
			// These succeed, now
			Assert.AreEqual(orig.Tup.Item1, dupl.Tup.Item1);
			Assert.AreEqual(orig.Tup.Item2, dupl.Tup.Item2);
		}
