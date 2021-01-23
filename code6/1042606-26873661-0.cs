    void Main()
    {
    	var mySchool = new List<School>{
    	new School{Student = "Student A", Teacher = "Teacher A", Subject = "Math", Marks = 80},
    	new School{Student = "Student B", Teacher = "Teacher A", Subject = "Math", Marks = 65},
    	new School{Student = "Student C", Teacher = "Teacher A", Subject = "Math", Marks = 95},
    	new School{Student = "Student A", Teacher = "Teacher B", Subject = "History", Marks = 80},
    	new School{Student = "Student B", Teacher = "Teacher B", Subject = "History", Marks = 100},
    	};
    	GroupByFilter("Student", mySchool);
    	GroupByFilter("Teacher", mySchool);
    	GroupByFilter("Subject", mySchool);
    }
      
    public void GroupByFilter(string filter, List<School> school)
    {
    	PropertyInfo prop = typeof(School).GetProperties()
									  .Where(x => x.Name == filter)
									  .First();
        
    	var grouping = from s in school
    				   group s by new {filter = prop.GetValue(s)} into gr
    				   select new {
    				   	Filter = gr.Key.filter,
    					Marks = gr.Sum(x => x.Marks)
    				   };
    	grouping.Dump(); // this is linqpad specific
    }
    
    // Define other methods and classes here
    public class School{
    	public string Student {get;set;}
    	public string Teacher {get;set;}
    	public string Subject {get;set;}
    	public int Marks {get;set;}
    }
