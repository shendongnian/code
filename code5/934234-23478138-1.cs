    // Since your students will use very typical activities, why not have a separate class just for activity type?
    public class Activity
    {
    	// Immutability is optional — I just tend to specify it by default.
    	public readonly string Name;
    
    	public Activity(string _Name)
    	{
    		this.Name = _Name;
    	}
    }
    
    public class Student
    {
    	public readonly string Name;
    
    	// It probably shouldn't be exposed like this
    	public Dictionary<Activity, int> Scores = new Dictionary<Activity, int>();
    
    	public Student(string _Name)
    	{
    		this.Name = _Name;
    	}
    
    	public string Report()
    	{
    		string result = Name;
    		if (Scores != null && Scores.Count > 0)
    		{
    			result += ", " + Scores.Count + " activities: ";
    			result += string.Join(", ", Scores.Select(s => c.Key.Name + "(" + c.Value + ")"));
    		}
    		return result;
    	}
    
    }
