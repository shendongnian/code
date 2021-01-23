    var excluded = _Context.TableId
                           .Where(x=>x.SecondaryId == myParameter)
                           .Select(x=>x.TableId)
                           .ToList();
    // get all the items from Table1 that aren't contained in the above list
    var query = _Context.Table1.Where(a=>!excluded.Any(a.TableId));
                
