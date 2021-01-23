    var predicate = PredicateBuilder.False<Words>();
    
    var query = from item in Words
                select item;
    
    var FaWords = "A B C".Split(' ');
    var EnWords = "D E F".Split(' ');
    
    foreach (string item in FaWords)
    {
        var item1 = item;
        predicate = predicate.Or(p => p.Word_Fa.Contains(item1));
    }
    
    foreach (string item in EnWords)
    {
        var item1 = item;
        predicate = predicate.Or(p => p.Word_En.Contains(item1));
    }
    
    return query.Where(predicate).toList();
