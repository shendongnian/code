    var intersectingUser = from l1 in list1
                           join l2 in list2
                           on new     { l1.FirstName, l1.LastName, l1.BirthDate }
                           equals new { l2.FirstName, l2.LastName, l2.BirthDate }
                           select new { ID1 = l1.id, ID2 = l2.id };
    foreach (var bothIDs in intersectingUser)
    {
        Console.WriteLine("ID in List1: {0} ID in List2: {1}", 
                         bothIDs.ID1, bothIDs.ID2);
    }
