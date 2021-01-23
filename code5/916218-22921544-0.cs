    var inComment = false; // start off assuming we're not in a comment
    // assume lines is some IEnumerable<string> representing the lines of your file,
    // perhaps from a call to File.ReadAllLines(<file name>)
    var result = 
        lines.Aggregate(new System.Text.StringBuilder(),
                        (builder, line) => {
	    		             if (!inComment)
                                 // more code here if "/*" isn't on its own line
                                 inComment = line.StartsWith("/*");
    
                             if (inComment)
                             {
                                 // more code here if "*/" isn't on its own line
                                 inComment &= !line.StartsWith("*/");
                                 return builder;
                             }
                         
                             if (!inComment) builder.AppendLine(line);
                             return builder;
                         }).ToString();
