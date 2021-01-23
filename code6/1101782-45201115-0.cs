    	public static class ListExtension
	    {
		  public static List<T> Splice<T>(this List<T> source, int start, int size)
		  {
			  var items = source.Skip(start).Take(size).ToList<T>(); 
			  if (source.Count >= size)
				  source.RemoveRange(start, size);
			  else 
				  source.Clear();
			  return items;
		  }
	    }
