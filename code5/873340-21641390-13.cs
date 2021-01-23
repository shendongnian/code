    session.CreateQuery(
    		"select parts from Car as car " +
    		"join car.AllParts as parts join fetch parts.SubParts where ...")
             .SetResultTransformer(new DistinctRootEntityResultTransformer())
             .List<Employee>();
