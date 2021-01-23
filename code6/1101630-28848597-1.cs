    // fix _ROW  in "pretty-print :)"  json text
    static private String FixJson(String json)
    {
        const String cRowString = "_ROW\" : {";      //  _ROW" : {"
        const String cEmpArrInvalid = "\" : \"\\n  \""; //  " : "\  "
        const String cEmpArrNormaly = "\":[]";          //  ":[]
    
        var lines = json.Split(new string[] { Environment.NewLine }, StringSplitOptions.None); // json-string to string array. delimiter = NewLine
        for (var i = 0; i < lines.Count(); i++) // loop strings
        {
            var line = lines[i]; // current string
    
            // oracle return json array with count=0 as "blabla": "\ ". I need "blabla": []
            char[] charsToTrim = { ',' };
            if (line.TrimEnd(charsToTrim).EndsWith(cEmpArrInvalid)) // find jarray-value with 0 elements. fucking Oracle's function :)
            {
                lines[i] = line.Replace(cEmpArrInvalid, cEmpArrNormaly); // replace bad substring( "\  " ) on empty array( [] )
                continue; // next string
            }
    
            if (!line.Contains(cRowString)) continue; // if not bad-string  => next string
    
            lines[i - 1] = lines[i - 1].Replace("{", "["); // _ROW found => in prev string replace object's start ( { ) on array's start ( [ )
            var pStart = line.IndexOf("\"", StringComparison.CurrentCulture); // find start position of field ( " )
    
            var sFind = ""; // string to search for end of object = backspace*pStart + }
            for (var k = 0; k < pStart; k++)
                sFind = sFind + ' ';
            sFind = sFind + '}';
    
            lines[i] = "{"; // replace singl-row property "blablabla_ROW": {   on start of object ( { )
    
            for (var j = i + 1; j < lines.Count(); j++) // from next line, find end of object. and replace object's end on array's end
            {
                if (!lines[j].StartsWith(sFind)) continue;  // if not end of object then next string
    
                lines[j + 1] = lines[j + 1].Replace("}", "]"); // found ! replace object's end on array's end
                break; // break loop
            }
        }
    
        return String.Join(Environment.NewLine, lines); // join string array into one string with newline-separator
    }
