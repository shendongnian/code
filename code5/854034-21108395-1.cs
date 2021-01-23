    var diffs = list1.Union(list2)
    	//Create groups where the key is subject and the value is the 
    	//list of positive marks for Term2 and negative marks for Term1
    	.GroupBy(c => c.Subject, c => c.Term == "Term2" ? c.Mark : -c.Mark)
    	.Select(s => new
    		{
    			Subject = s.Key,
    			Difference = s.Sum()
    		})
    	.Where(s => s.Difference != 0);
    
    var diffs2 = list1.Union(list2)
    	.GroupBy(c => c.Subject)
    	.Select(s =>
    		{
    			//For a more general and slighly different algorithm, you can 
    			//subtract all the marks for a each subject except the last term 
    			//mark from the last term mark (e.g. 95 - 90 for English or 30 - 
    			//n/a because there's only one term for Physics
    			var marks = s.OrderByDescending(c => c.Term).Select(c => c.Mark);
    			var lastTermMark = marks.First();
    			return new
    				{
    					Subject = s.Key,
    					Difference = marks.Skip(1)
    						.Aggregate(lastTermMark, (diff, mark) => diff - mark)
    				};
    		})
    	.Where(s => s.Difference != 0);
