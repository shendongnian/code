	public class LoadedStudent
	{
		public int ID;
		public Student Primary;
		public Student[] Duplicates;
	}
	public List<LoadedStudent> LoadStudents(IEnumerable<Student> source)
	{
		var query = 
			from s in students
			group s by s.ID into grp
			let primary = grp.First()
			select new LoadedStudent 
			{ 
				ID = primary.ID,
				Primary = primary,
				Duplicates = grp.Skip(1).ToArray()
			};
		
		return Query.ToList();
	}
