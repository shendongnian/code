    public static class Linq
    {
    	public class StringParameters
    	{
    		public string Text { get; set; }
    		public int Position { get; set; }
    	
    		public StringParameters(string text, int position)
    		{
    			this.Text = text;
    			this.Position = position;
    		}
    	}
    
    	public static StringParameters At(this string text, Func<char> func)
    	{
    		char c = func();
    		int index = text.IndexOf(c);
    		if (index > 0)
    		{
    			int index2 = text.IndexOf(c, index + 1);
    			if (index2 > index)
    			{
    				text = text.Substring(index2, text.Length - index2);
    			}
    	
    			return new StringParameters(text, index2 + 1);
    		}
    	
    		return new StringParameters(null, -1);
    	}
    
       public static string Cut(this StringParameters parameters)
       {
           return parameters.Text.Substring(parameters.Position);
       }
    }
