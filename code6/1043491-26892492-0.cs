    void Main()
    {
    	var mySchool = new List<School>{
    	new School{Student = "Student A", Teacher = "Teacher A", Subject = "Math", Grades = 80},
    	new School{Student = "Student B", Teacher = "Teacher A", Subject = "Math", Grades = 65},
    	new School{Student = "Student C", Teacher = "Teacher A", Subject = "Math", Grades = 95},
    	new School{Student = "Student A", Teacher = "Teacher B", Subject = "History", Grades = 80},
    	new School{Student = "Student B", Teacher = "Teacher B", Subject = "History", Grades = 100},
    	new School{Student = "Student A", Teacher = "Teacher C", Subject = "English", Grades = 100},
    	new School{Student = "Student C", Teacher = "Teacher B", Subject = "English", Grades = 100},
    	new School{Student = "Student D", Teacher = "Teacher B", Subject = "English", Grades = 90},
    	};
    	
     
    	GroupByFilters("Teacher", "Subject", mySchool);
    	GroupByFilters("Subject", "Teacher", mySchool);
    }
    
    
     
    public void GroupByFilters(string filter1, string filter2, List<School> school)
    {
    
    	PropertyInfo prop1 = typeof(School).GetProperties()
    									  .Where(x => x.Name == filter1)
    									  .First();
    									  
    	PropertyInfo prop2 = typeof(School).GetProperties()
    									  .Where(x => x.Name == filter2)
    									  .First();									  
    	var grouping = from s in school
    				   group s by new {filter1 = prop1.GetValue(s), filter2 = prop2.GetValue(s)} into gr
    				   select new {
    				   	Filter1 = gr.Key.filter1,
    				   	Filter2 = gr.Key.filter2,
    					TotalGrades = gr.Sum(x => x.Grades),
    					Count = gr.Count(),
    					Average = gr.Average(x => x.Grades)
    				   };
    	grouping.Dump(); // Linq pad specific 
    }
    
    // Define other methods and classes here
    public class School{
    	public string Student {get;set;}
    	public string Teacher {get;set;}
    	public string Subject {get;set;}
    	public int Grades {get;set;}
    }
 
