    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var LectureReportStudent = new List<LectureReportStudent>();
    		
            List<StudentModel> testList= LectureReportStudent
                .Select(x => new StudentModel
                {
    
                    Name = x.Student.FirstName + "" + x.Student.LastName,
                    Position = x.Student.JobTitle,
                    JobId = x.LectureReport.LectureId,
                    StudentId = x.StudentlId,
                    LectureId = x.LectureReportId,
                    Date = x.Date
    
                }).ToList();
    	}
    	
    	public class LectureReportStudent
    	{
    		public LectureReport LectureReport { get; set; }
    		public Student Student { get; set; }
    		public int StudentlId { get; set; }
    		public int LectureReportId { get; set; }
    		public DateTime Date { get; set; }
    	}
    	
    	public class LectureReport
    	{
    		public int LectureId { get; set; }
    		public Lecture Lecture { get; set; }
    	
    	}
    
    	public class Lecture {}
    	
    	public class Student 
    	{
    		public int stuIds { get; set; }
    		public string FirstName { get; set; }
    		public string LastName { get; set; }
    		public string JobTitle { get; set; }		
    	
    	}
    	
    	public class StudentModel 
    	{
    		public string Name  { get; set; }
    		public string Position { get; set; }
            public int JobId { get; set; }
    		public int StudentId { get; set; }
    		public int LectureId { get; set; }
    		public DateTime Date  { get; set; }
    	}
    }
