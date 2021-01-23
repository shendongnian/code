    using System.IO;
    using System.Text;
    
    public class Test
    {
    	public static void Main()
    	{
    		StringBuilder sb = new StringBuilder();
    		string ExceptionDetails="<names><FirstName>John</FirstName><SecondName>White</SecondName></names>";
    		using (XmlReader reader = XmlReader.Create(new StringReader(ExceptionDetails)))
    		{
    		    string tagName = string.Empty;
    			while (reader.Read())
        		{
    		       if (reader.NodeType == XmlNodeType.Element)
    		           tagName = reader.Name;
    		       else if (reader.NodeType == XmlNodeType.Text)
    		       {               
    		         	sb.Append(tagName);
    		            sb.Append(":"); //Read tag title
    		            sb.Append(reader.Value); sb.Append("<br/>");                      
    		       }
    			}
    		}
    		Console.WriteLine(sb.ToString());
    	}
    }
