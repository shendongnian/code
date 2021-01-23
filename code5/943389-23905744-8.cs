    // here the attributeIds collection represents attributes to be found
    var attributeIds = new List<int> { 1, 4, 5 };
    // Let's again start with definition of the outer/top query
    // which will return all files, which do meet all filter requirements
    var query = session.QueryOver<Files>(() => file);
    // here we will take each attribute and create a subquery
    // all these subqueries, will be joined with AND
    // so only these files, which do have all attributes, will be selected
    foreach (var attrId in attributeIds)
    {
        // create the subquery, returning the FileId
        Attrs attribute = null;
        var subQueryForAttribute = QueryOver.Of<Files_Attrs>()
                // no need to join, all the stuff is in the pairing table
                .Select(x => x.file.id)
                ;
        var id = attrId; // local variable
        // and convert them into where condition
        subQueryForAttribute.Where(pair => pair.attr.id == id);
        // finally, add this subquery as a restriction to the top level query
        query.WithSubquery
            .WhereProperty(file => file.id)
            .In(subQueryForAttribute);
    }
