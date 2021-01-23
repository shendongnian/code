    string keep = @"EmpId,Sex,Address,Address\Zip,Address2,Address2\Country";
    string desStr = "Employee";
    string[] strArr = keep.Split(',');
    
    var nodesToDelete = xDoc.Root.Descendants(desStr)
                    .SelectMany(el => el.Descendants()
                                      .Where(a => 
    								  	{
    										if (a.Parent.Name == desStr)
    										{
    											return !strArr.Contains(a.Name.ToString());
    										}
    										else
    										{
    											return !strArr.Contains(a.Parent.Name + @"\" + a.Name);
    										}
    								  		
    									}));
    
    foreach (var node in nodesToDelete.ToList())
          node.Remove();
