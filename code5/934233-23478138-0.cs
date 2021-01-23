    public class Activity
    {
    	public readonly string Name;
    
    	public Activity(string _Name)
    	{
    		this.Name = _Name;
    	}
    }
    
    public class Student
    {
    	public readonly string Name;
    	public Dictionary<Activity, int> Scores;
    
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
    			result += string.Join(", ", Scores(s => c.Key.Name + "(" + c.Value + ")"));
    		}
    		return result;
    	}
    
    }
