    public abstract class Person : ICloneable
    {
    	public string FirstName { get; set; }
    	public string Surname { get; set; }
    
    	public Person()
    	{
    
    	}
    
    	public Person(string firstName, string surname)
    	{
    		this.FirstName = firstName;
    		this.Surname = surname;
    	}
    
    	public abstract object Clone();
    }
    
    public sealed class Student : Person
    {
    	public int StudentId { get; set; }
    	public string CourseTitle { get; set; }
    
    	public Student()
    	{
    
    	}
    
    	public Student(int studentId, string courseTitle, string firstName, string surname)
    		: base(firstName, surname)
    	{
    		this.StudentId = studentId;
    		this.CourseTitle = courseTitle;
    	}
    
    	public override object Clone()
    	{
    		Student clone = new Student(StudentId, CourseTitle, FirstName, Surname);
    		return clone;
    	}
    }
