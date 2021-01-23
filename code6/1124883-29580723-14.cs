    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public static class Program
    {
    	public static void Main()
    	{
    		var LectureReportStudent = GetLectureReportStudent();
    		
    		var testList = LectureReportStudent
    			
    		.Select(x => new StudentModel {
    				
                Name = x.Student.FirstName + " " + x.Student.LastName,
                Position = x.Student.JobTitle,
                JobId = x.LectureReport.LectureId,
                StudentId = x.StudentlId,
                LectureId = x.LectureReportId,
                Date = x.Date
    
    		}).GroupBy(x => new {
    		
    			StudentId = x.StudentId,
    			LectureId = x.LectureId
    	
    		}).Select(x => new StudentModel() {
    	
    			StudentId = x.Key.StudentId, 
    			LectureId = x.Key.LectureId,
    			DaysOnLecture = x.Count(),
    			LectureCount = -1 // how do we sum all the DaysOnLecture??
    		
    		}).ToList();
    		
    		foreach(var t in testList)
    		{
    			Console.WriteLine("StudentId: " + t.StudentId);
    			Console.WriteLine("LectureId: " + t.LectureId);
    			Console.WriteLine("DaysOnLecture: " + t.DaysOnLecture);
    			Console.WriteLine("LectureCount: " + t.LectureCount);
    
    			Console.WriteLine();
    		}
    	}
    	
    	public static void Dump(this IEnumerable<StudentModel> query, 
            string title)
    	{
    		Console.WriteLine(title);
    		
    		foreach(var i in query)
    		{
    			Console.WriteLine();
    			
    			Console.Write(i.Name + ", ");			
    			Console.Write(i.Position + ", ");
    			Console.Write(i.JobId + ", ");
    			Console.Write(i.StudentId + ", ");
    			Console.Write(i.LectureId + ", ");
    			Console.Write(i.Date + "");
    		}
    		
    		Console.WriteLine();
    	}
    	
    	public static List<LectureReportStudent> GetLectureReportStudent()
    	{
    		var list = new List<LectureReportStudent>();
    		
    		var lectureId = 0;
    		var studentId = 0;
    		for(var i = 0; i < 24; ++i)
    		{
    			if(i % 12 == 0)
    			{
    				++studentId;
    				lectureId = 1;
    			}
    			
    			if(i % 3 == 0)
    				++lectureId;
    			
    			var lrs = new LectureReportStudent()
    			{
    				LectureReport = new LectureReport() { 
                        LectureId = lectureId 
                    },
    				Student = new Student() { 
                        FirstName = "foo", 
                        LastName = "bar", 
                        JobTitle = "Job" },
    				StudentlId = studentId,
    				LectureReportId = lectureId,
    				Date = DateTime.Now
    			};
    			list.Add(lrs);
    			
    			// Console.WriteLine(studentId + ":" + lectureId);
    		}
    		
    		return list;
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
    		public int DaysOnLecture  { get; set; }
    		public int LectureCount  { get; set; }
    		public int LectureReportId  { get; set; }
    	}
    }
