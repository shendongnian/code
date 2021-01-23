    foreach (var parent in parents)
    {
	   var id = parent.Id;
	   var parentEntity = new Parent();
	   this.Context.Set<Parent>().Add(parentEntity);
	   parentEntity.CreatedOn = DateTime.UtcNow;
	   ...
		
	   foreach (var child in parents[id].Children)
	   {
		   var childEntity = new Child();
		   //this.Context.Set<Child>().Add(childEntity);
		   parent.Children.Add(childEntity);
		   childEntity.CreatedOn = DateTime.UtcNow;
		   ...
	   }
    }
