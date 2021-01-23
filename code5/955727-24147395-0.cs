    foreach(string line in lines)
    {
        using(var parser = new TextFieldParser(line))
        {
            var sqlfmt = "insert into mytable values ({0})";
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            var fields = parser.ReadFields();
            var insert = string.Format(sqlfmt, string.Join(",", fields));
            // todo: somedb.execute_sqlcommand(insert); or something
        }
    }
