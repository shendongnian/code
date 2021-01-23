    var data = new List<Bob>
    {
    	new Bob { Id = 1, Name = "Base", Description = "Base description", Notes = "Awesome object", ParentId = null },
    	new Bob { Id = 2, Name = "", Description = "", Notes = "", ParentId = 1 },
    	new Bob { Id = 3, Name = "Custom Name", Description = "", Notes = "", ParentId = 2 },
    	new Bob { Id = 4, Name = "", Description = "Final object", Notes = "", ParentId = 3 },
    };
    var map = data.ToDictionary(d => d.Id, d => d);
    
    data.ForEach(row => CopyFromParent(map, row, row.ParentId.HasValue ? map[row.ParentId.Value] : null));
    data.Dump();
    
    }
    
    void CopyFromParent(Dictionary<int, Bob> map, Bob target, Bob current)
    {
    	// set properties
    	if (current != null && string.IsNullOrEmpty(target.Name) && !string.IsNullOrEmpty(current.Name)) target.Name = current.Name;
    	if (current != null && string.IsNullOrEmpty(target.Description) && !string.IsNullOrEmpty(current.Description)) target.Description = current.Description;
    	if (current != null && string.IsNullOrEmpty(target.Notes) && !string.IsNullOrEmpty(current.Notes)) target.Notes = current.Notes;
    	
    	// dive deeper if we need to, and if we can
    	var needToDive = string.IsNullOrEmpty(target.Name) || string.IsNullOrEmpty(target.Description) || string.IsNullOrEmpty(target.Notes);
    	var canDive = current != null && current.ParentId.HasValue && map.ContainsKey(current.ParentId.Value);
    	if (needToDive && canDive)
    	{
    		CopyFromParent(map, target, map[current.ParentId.Value]);
    	}
    }
    
    class Bob
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public string Description { get; set; }
    	public string Notes { get; set; }
    	public int? ParentId { get; set; }
    }
