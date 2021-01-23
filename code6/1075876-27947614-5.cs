    public class Example {
    	private IRepository repos;
    	
    	//pass in your database context abstract here
    	public Example(IRepository repos){
    		this.repos = repos;
    	}
    	
    	public IEnumerable<Person> PostMethod(string name = "All", string age = "All",
    	string height = "All", string weight = "All") {
    	//reference your database abstract here
    	return repos.People.Where(x => name == "All" || x.Name == name)
    		.Where(x => age == "All" || x.Age.Contains(age))
    		.Where(x => height == "All" || x.Height.StartsWith(height))
    		.Where(x => weight == "All" || x.Weight.EndsWith(weight));
    	}
    }
