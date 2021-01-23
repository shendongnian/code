    public class TaskCollection : IList<Task>, IList
    {
        int IList.Add(object value)
		{
            // just call the generic version
			Add((Task)value);
		}
	 
	 	int IList.IndexOf(object value)
		{
            // just call the generic version
			return IndexOf((Task)value);
		}
        ...
    }
