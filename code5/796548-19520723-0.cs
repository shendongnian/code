    String query = "CREATE TABLE [ dbo ] . [ worktype_template ] ( [ worktype_key ] [ int ] NULL , [ template_key ] [ int ] NULL ) ON [ PRIMARY ]";
    query = query.Replace(" . ", ".");
    query = query.Replace("[ ", "[");
    query = query.Replace(" ]", "]");
    // Selects what is between parenthesizes 
    String fieldsString = new String(query.SkipWhile(c => c != '(').TakeWhile(c => c != ')').ToArray());
    // Selects the fields
    String[] fields = fieldsString.Split(',').Select(line => new Regex("\\[\\w+\\]").Match(line).Value).ToArray();
    // Selects table name
    String tableName = new Regex("\\[\\w+\\](\\.\\[\\w+\\])*").Match(query).Value;
