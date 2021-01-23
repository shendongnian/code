    var Students = new List<Student>() {
    		new Student() {StudentId = 1, Name ="John", MarkId = 1},
    		new Student() {StudentId = 1, Name ="Paul", MarkId = 1},
    		new Student() {StudentId = 1, Name ="Steve", MarkId = 1},
    		new Student() {StudentId = 1, Name ="John", MarkId = 2},
    		new Student() {StudentId = 1, Name ="Paul", MarkId = 3},
    		new Student() {StudentId = 1, Name ="Steve", MarkId = 1},
    		new Student() {StudentId = 1, Name ="Paul", MarkId = 3},
    		new Student() {StudentId = 1, Name ="John"  },
    		new Student() {StudentId = 1, Name ="Steve"  },
    		new Student() {StudentId = 1, Name ="John", MarkId = 1}
    		
    	};
    	
    	var Marks = new List<Mark>() {
    		new Mark() {MarkId = 1, Value = 60},
    		new Mark() {MarkId = 2, Value = 80},
    		new Mark() {MarkId = 3, Value = 100}
    	};
    	
    	var StudentMarks = Students
    						.GroupJoin(
    							Marks,
    							st => st.MarkId,
    							mk => mk.MarkId,
    							(x,y) => new {
    										    StudentId = x.StudentId, 
    										    Name = x.Name,
    											Mark = y.Select (z => z.Value).SingleOrDefault()
    										  }
    						)
    						.Dump();
    
    	
    }
    
    public class Student
    {
    	public int StudentId { get; set; }
    	public string Name { get; set; }
    	public int MarkId { get; set; }
    }
    
    public class Mark
    {
    	public int MarkId { get; set; }
    	public int Value { get; set; }
    }
