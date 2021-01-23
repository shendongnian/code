    public static void Main(){
    	var info = File.ReadAllLines(filename.csv);
    	rows.Select(x => {
    				var data = x.Split(',');
    				return new {id = data[0], name = GetName(data[1]), price = data[2]};
    			})
    	.OrderBy(x => x.id)
    	.ToList()
    	.ForEach(x => listbox.Items.Add(string.Format(format1, x.id, x.name, x.price)));
    }
    			
    public static string GetName(string type)
    {
    	switch(type)
    	{
    		case "t":
    			return "Toy";
    		case "m":
    			return "Mat";
    		case "l":
    			return "lunch";
    		default:
    			throw new NotImplementedException();
    	}
    }
