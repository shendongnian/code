    	public class Parent
	{
		private int Id;
		private String Title;
		private int? Parent;
		// Private static fields for managing Ids and the list of all instances
		private static List<Parent> _allParents = new List<Parent>();
		private static int _nextId = 0;
		// Default constructor
		public Parent()
		{
			// Set default field values.
			this.Id = _nextId++;
			this.Title = "";
			this.Parent = null;
			// Store the new object in the static collection.
			_allParents.Add(this);
		}
		/// <summary>
		/// Constructs a list of Parent objects whose Ids have corresponding Parent objects.
		/// NOTE: This method returns a List that includes the Parent object with the Id
		/// passed in.  This will be the first item in the List and should be skipped if
		/// only higher level relationships are required.
		/// </summary>
		/// <param name="Id">Nullable<int> Id of the item whose parents are to be found.</param>
		/// <returns>List<Parent> of the Parents objects</returns>
		public List<Parent> ListParents(int? Id)
		{
			List<Parent> parents = new List<Parent>();
			// Id values that are null mark the end of the ancestor chain
			while (Id.HasValue)
			{
				// Find the Parent with the requested Id
				var parent = _allParents.Find(p => { return this.Id == p.Id; });
				// null means no Parent object with the requested Id exists
				if (null != parent)
				{
					// Add the Parent and its parents.
					parents.Add(parent);
					// Check for the next Id
					Id = parent.Id;
				}
			}
			return parents;
		}
		public String GetAllParents(int? Id)
		{
			StringBuilder allParents = new StringBuilder();
			// Find all the parents
			List<Parent> parents = ListParents(Id);
			// Add the Title of each parent in the list to the result
			for(int n = 0; n < parents.Count; n++)
			{
				allParents.Append(parents[n].Title);
				// Seperate all but the last parent with commas
				if(n < (parents.Count - 1))
					allParents.Append(", ");
			}
			return allParents.ToString();
		}
	}
