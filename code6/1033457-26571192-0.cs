    var predicate = PredicateBuilder.False<Words>();
				
	var query = from item in Words
				select item;
							
	var FaWords = "A B C".Split(' ');
	var EnWords = "D E F".Split(' ');
						
	foreach (string item in FaWords)
	{
		predicate = predicate.Or(p => p.Word_Fa.Contains(item));
	}
	
	foreach (string item in EnWords)
	{
		predicate = predicate.Or(p => p.Word_En.Contains(item));
	}
	
	return query.Where(predicate).toList();
