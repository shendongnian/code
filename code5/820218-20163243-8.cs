    private static YourDBContext ctx = new YourDbContext();
    public static class HelperMethods {
	public static string GetCityName(string cityId){ //your olddata is string
	string name = (from c in ctx.City
					where c.Id == cityId
					 select c.Name);
	
	return name;
	}
