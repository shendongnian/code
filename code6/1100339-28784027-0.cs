    // Simplified. You should implement it correctly if you want to go this way.
	public class ObjectItemEqualityComparer : IEqualityComparer<ObjectItem> 
	{
		public bool Equals(ObjectItem o1, ObjectItem o2)
		{
			return o1.Id == o2.Id;
		}
		
		public int GetHashCode(ObjectItem o)
		{
			return o.Id;
		}
	}
    var result = StudentWithAge.Union(StudentWithSexAndComplexion, 
                                      new ObjectItemEqualityComparer());
