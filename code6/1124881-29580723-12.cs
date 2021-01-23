	public static void Main()
	{
		var joinTable = FakeJoinTable();
		
		var query = joinTable
			.GroupBy(g => new { g.StudentId, g.LectureId } );
		
		foreach(var x in query)
		{
			Console.WriteLine("StudentId:" + x.Key.StudentId);
			Console.WriteLine("LectureId:" + x.Key.LectureId);
			Console.WriteLine("CountStudentId:" + "How do we sum ALL the lectures?!");
			Console.WriteLine("CountStudentIdLectureId:" + x.Count());
			Console.WriteLine();
		}
	}
	
	public static List<JoinTable> FakeJoinTable()
	{
		var list = new List<JoinTable>();
		var studentId = 0;
		var lectureId = 0;
		for(int i = 0; i < 20; ++i)
		{
			if(i % 10 == 0) 
			{	
				++studentId;
				lectureId = 0;
			}
			if(i % 3 == 0) ++lectureId;
			list.Add(new JoinTable() { StudentId = studentId, LectureId = lectureId });
		}
		return list;
	}
	
	public class JoinTable
	{
		public int StudentId { get; set; }
		public int LectureId { get; set; }
	}
}
