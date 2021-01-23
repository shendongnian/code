    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    					
    public class Program
    {
    	public static void Main()
    	{
    		JsonSerializerSettings settings = new JsonSerializerSettings();
    		// Comment out the following line and CanConvert() never gets called on 
            // FooConverter for any type yet the FooConverter is still working due
            // to the JsonConverter attribute applied to Wrapper.Foo
    		settings.Converters.Add(new FooConverter());
    		settings.Converters.Add(new BarConverter());
    		settings.Formatting = Formatting.Indented;
    		
    		Wrapper w = new Wrapper
    		{
    			Foo = new Foo
    			{
    				A = "bada",
    				B = "boom",
    			},
    			Bar = new Bar
    			{
    				C = "bada",
    				D = "bing"
    			}
    		};
    		string json = JsonConvert.SerializeObject(w, settings);
    		Console.WriteLine(json);
    	}
    	
    	class Wrapper
    	{
    		// Comment out this attribute and CanConvert will be called on FooConverter
            // for type Foo due to the fact that the FooConverter has been added to the
            // JsonSerializerSettings
    		[JsonConverter(typeof(FooConverter))]
    		public Foo Foo { get; set; }
    		public Bar Bar { get; set; }
    	}
    	
    	class Foo
    	{
    		public string A { get; set; }
    		public string B { get; set; }
    	}
    	
    	class Bar
    	{
    		public string C { get; set; }
    		public string D { get; set; }
    	}
    	
    	class FooConverter : JsonConverter
    	{
    		public override bool CanConvert(Type objectType)
    		{
    			bool result = typeof(Foo).IsAssignableFrom(objectType);
    			Console.WriteLine("FooConverter CanConvert() called for type " +
                                  objectType.Name + " (result = " + result + ")");
    			return result;
    		}
    	
    		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    		{
    			var foo = (Foo) value;
    			JObject jo = new JObject();
    			jo.Add("AplusB", new JValue(foo.A + " " + foo.B));
    			jo.WriteTo(writer);
    		}
    	
    		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    		{
    			throw new NotImplementedException();
    		}
    	}
    	
    	class BarConverter : JsonConverter
    	{
    		public override bool CanConvert(Type objectType)
    		{
    			bool result = typeof(Bar).IsAssignableFrom(objectType);
    			Console.WriteLine("BarConverter CanConvert() called for type " + 
                                  objectType.Name + " (result = " + result + ")");
    			return result;
    		}
    	
    		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    		{
    			var bar = (Bar) value;
    			JObject jo = new JObject();
    			jo.Add("CplusD", new JValue(bar.C + " " + bar.D));
    			jo.WriteTo(writer);
    		}
    	
    		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    		{
    			throw new NotImplementedException();
    		}
    	}
    }
