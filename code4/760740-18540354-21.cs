    public class Program
    {
    	YourContext context = new YourContext();
    
    	public int MaxStudentId()
    	{
    		return context.Student.MaxId(s => s.Id);
    	}
    
    	public static void Main(string[] args)
    	{
    		Console.WriteLine("Max student id: {0}", MaxStudentId());
    	}
    }
    
    public static class Extensions
    {
        public static int MaxId<TSource>(this IQueryable<TSource> source, Func<TSource, int> selector)
        {
            return source.Select(selector).DefaultIfEmpty(0).Max();
        }
    }
