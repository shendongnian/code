    using System.Linq;
    ...
    ...
    static void Main(string[] args)
    {
    	List<Student> students = new List<Student>()
    								 {
    									 new Student("Finn", 0),
    									 new Student("AJ", 0),
    									 new Student("Sami", 0),
    									 new Student("John", 0),
    									 new Student("Rey", 0)
    								 };
    
    	List<Test> tests = new List<Test>()
    								 {
    									 new Test("Finn", 100),
    									 new Test("AJ", 97),
    									 new Test("Sami", 80),
    									 new Test("John", 72),
    									 new Test("Rey", 61)
    								 };
    
    	tests.ForEach(
    		t =>
    			{ students.Where(s => s.name == t.nameOfStudent).FirstOrDefault().score = t.scoreOfTest; });
    }
