    string subschemaSQL =   "SELECT subschema.Id, subschema.name as subschemaName, locus.Name as locusName " + 
                            "FROM subschema " +
                            "LEFT JOIN subschemamembers ON subschemamembers.SubSchemaID = subschema.PrimKey " +
                            "LEFT JOIN locus ON subschemamembers.LocusID = locus.ID " +
                            "WHERE  subschema.OrganismID = ? " +
                            "ORDER BY subschema.Id, locusName";
    XElement rootNode = new XElement("ResponseSubschemas",
                                     new XElement("organism", organismID),
                                     new XElement("Subschemas"));
    XElement subschemasNode = rootNode.Element("Subschemas");
    //this should probably be used in a 'using' block,
    //leaving your code intact for readability:
    DbDataReader subschemaReader = conn.Query(subschemaSQL, organismID);
    DataTable table = new DataTable();
    table.Load(subschemaReader);
    subSchemasNode.Add(
       table.Rows
            .Select(row => new {
                                 Id = row["id"].ToString(),
                                 SubschemaName = row["subschemaName"].ToString(),
                                 LocusName = row["locusName"].ToString()
                               })
            .GroupBy(item => new { Id = item.Id, SubschemaName = item.SubschemaName)
            .Select(@group =>
                     new XElement("Subschema",
                                  new XElement("id", @group.Key.Id),
                                  new XElement("name", @group.Key.SubschemaName),
                                  new XElement("loci", @group.Select(item => new XElement("locus", item.LocusName)).ToArray())))
            .ToArray());
