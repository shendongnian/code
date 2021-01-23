    // here the attributes collection represents search filter
    // ... settings for which is user looking for
    var attributes = new List<Attrs>
    {
        new Attrs{ name = "mode", value = "read-only" },
        new Attrs{ name = "view", value = "visible" }
    };
    // Let's start with definition of the outer/top query
    // which will return all files, which do meet all filter requirements
    var query = session.QueryOver<Files>(() => file);
    // here we will take each attribute and create a subquery
    // all these subqueries, will be joined with AND
    // so only these files, which do have all attributes, will be selected
    foreach (var attr in attributes)
    {
        // create the subquery, returning the FileId
        Attrs attribute = null;
        var subQueryForAttribute = QueryOver.Of<Files_Attrs>()
                .JoinQueryOver(fa => fa.attr, () => attribute)
                .Select(x => x.file.id)
                ;
     
        // now, take name and value
        var name = attr.name;
        var value = attr.value;
   
        // and convert them into where condition
        subQueryForAttribute.Where(a => attribute.name == name);
        subQueryForAttribute.Where(a => attribute.value == value);
        // finally, add this subquery as a restriction to the top level query
        query.WithSubquery
            .WhereProperty(file => file.id)
            .In(subQueryForAttribute);
    }
