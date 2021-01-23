    void Main()
    {
    	var sw = new StreamReader(@"d:\Rental2.txt");
    	try
    	{
    		//explicit
    		Rental r = new Rental();
    		var Explicit = r.Deserialise(sw.BaseStream);
    		Console.WriteLine(Explicit);
    		
    		//implicit
    		var rrr = new Rental();
    		var Implicit = rrr.Deserialise(sw.BaseStream);
    		Console.WriteLine(Implicit);
    	}
    	catch(Exception)
    	{
    	}
    	finally
    	{ 
    	    sw.Close();
    	}
    }
    
    public class Rental
    {
    	public int ID {get;set;}
    }
    
    public static class Extensions
    {
     public static T Deserialise<T>(this T Object,Stream stream)
    	{
    		if (stream.CanSeek)
    		{
    			stream.Position=0;
    		}
    		var ser = new XmlSerializer(typeof(T));
    		return (T)ser.Deserialize(stream);
    	}
    }
