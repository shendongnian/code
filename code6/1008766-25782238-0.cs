    var subquery = Session.QueryOver<Table>(() => x)
        				.SelectList(list => list
        				.SelectMax(() => x.Date)
        				.SelectGroup(() => x.Sub.Id))
        				.List<object[]>().Select(p => p[0]).ToArray();
        
        			
        			var CorrespondingIds = Session.QueryOver<Table>(() => x)
        				.WhereRestrictionOn(() => x.Date).IsIn(subquery)
        				.Select(p => p.Id).List<int>().ToArray();
        
        			var result = uow.Session.QueryOver<Table>(() => x).WhereRestrictionOn(() => x.Id).IsIn(CorrespondingIds).Left.JoinQueryOver(p => p.Sub).List();
