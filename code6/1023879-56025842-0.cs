	void Main()
	{
		//    1
		//   2 3
		//  4    
		// 5 6
		
		// Child nodes are all those that are not parents: i.e.: 5, 6, 3
		
		var details = new[] {
			new Member_Details { Member_Id = 1, Member_Name = "Node 1" },
			new Member_Details { Member_Id = 2, Member_Name = "Node 2" },
			new Member_Details { Member_Id = 3, Member_Name = "Node 3" },
			new Member_Details { Member_Id = 4, Member_Name = "Node 4" },
			new Member_Details { Member_Id = 5, Member_Name = "Node 5" },
			new Member_Details { Member_Id = 6, Member_Name = "Node 6" },
		};
		
		var relationships = new[] {
			new ParentChildMap { parent_id = 1, child_id = 2 },
			new ParentChildMap { parent_id = 1, child_id = 3 },
			new ParentChildMap { parent_id = 2, child_id = 4 },
			new ParentChildMap { parent_id = 4, child_id = 5 },
			new ParentChildMap { parent_id = 4, child_id = 6 }
		};
		
		var children = relationships
			.GroupJoin(relationships, r1 => r1.child_id, r2 => r2.parent_id, (r1, r2) => r2
				.Select(x => new { Inner = r1.child_id, Outer = x.child_id})
				.DefaultIfEmpty(new { Inner = r1.child_id, Outer = 0 }))
			.SelectMany(x => x)
			.Where(x => x.Outer == 0)
			.Join(details, r => r.Inner, d => d.Member_Id, (r, d) => new {Id = r.Inner, Name = d.Member_Name});
		
		foreach (var child in children)
		{
			Console.WriteLine($"ID: {child.Id}, Name: {child.Name}");
		}
	}
	
	public class ParentChildMap
	{
		public int parent_id;
	    public int child_id;
	}
	
	public class Member_Details
	{
		public int Member_Id;
	    public string Member_Name;
	}
