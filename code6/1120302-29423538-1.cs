    using System;
    using System.Drawing;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		JObject obj = JObject.Parse(@"{ ""Color"" : 16711680 }");
    		
    		JsonSerializer serializer = new JsonSerializer();
    		serializer.Converters.Add(new ColorConverter());
    		
    		Color c = obj["Color"].ToObject<Color>(serializer);
    		Console.WriteLine(c.ToString());
    	}
    }
    
    class ColorConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return (objectType == typeof(Color));
    	}
    	
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		writer.WriteValue(((Color)value).ToArgb());
    	}
    	
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		return Color.FromArgb(Convert.ToInt32(reader.Value));
    	}
    }
