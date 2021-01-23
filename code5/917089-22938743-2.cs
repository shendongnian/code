    QueryCase querycase;
    string querytext, attributeName1, attributeName2;
    querycase = QueryCase.Alpha; // switch between possible queries
    // somewhere later in your code...
    switch (querycase)
    {
        case QueryCase.Alpha:
            attributeName1 = "attribute1";
            attributeName2 = "attribute2";
        case QueryCase.Beta:
            attributeName1 = "attribute3";
            attributeName2 = "attribute4";
        default:
            throw new NotImplementedException(string.Format("unrecognized query case (was {0})", (int)querycase));
    }
    querytext = string.Format("select * from table1 where {0}=@1 and {1}=@2", attributeName1, attributeName2);
    adp.SelectCommand.CommandText = querytext;
