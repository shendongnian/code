    public class Xml
    {
    	public static string Serialize(object objectToSerialize)
    	{
    		var mem = new MemoryStream();
    		var ser = new XmlSerializer(objectToSerialize.GetType());
    		ser.Serialize(mem, objectToSerialize);
    		var utf8 = new UTF8Encoding();
    		return utf8.GetString(mem.ToArray());
    	}
    }
