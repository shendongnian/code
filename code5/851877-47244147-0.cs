    <#@ template debug="true" hostspecific="true" language="C#" #>
    <#@ output extension=".cs" #>
    <#@ assembly name="System.Core" #>
    <#@ assembly name="Microsoft.VisualBasic.dll" #> 
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="Microsoft.VisualBasic.FileIO" #>
    
    // Generated code
    using System.Collections.Generic;
    
    namespace Foo
    {
        // ISO 639-3
        // http://www-01.sil.org/iso639-3/download.asp
        public class ISO_639_3
        {
            // The three-letter 639-3 identifier
            public string Id { get; set; }
            // Equivalent 639-2 identifier of the bibliographic applications code set, if there is one
            public string Part2B { get; set; }
            // Equivalent 639-2 identifier of the terminology applications code set, if there is one
            public string Part2T { get; set; }
            // Equivalent 639-1 identifier, if there is one
            public string Part1 { get; set; }
            // I(ndividual), M(acrolanguage), S(pecial)
            public string Scope { get; set; }
            // A(ncient), C(onstructed), E(xtinct), H(istorical), L(iving), S(pecial)
            public string Language_Type { get; set; }
            // Reference language name
            public string Ref_Name { get; set; }
            // Comment relating to one or more of the columns
            public string Comment { get; set; }
    
    		// Create a list of all known codes
    		public static List<ISO_639_3> Create()
    		{
    			List<ISO_639_3> list = new List<ISO_639_3> {
    <# 
        // Setup text parser
    	string filename = this.Host.ResolvePath("iso-639-3.tab"); 
        TextFieldParser tfp = new TextFieldParser(filename)
        {
            TextFieldType = FieldType.Delimited,
            Delimiters = new[] { ",", "\t" },
            HasFieldsEnclosedInQuotes = true,
            TrimWhiteSpace = true
        };
    
        // Read first row as header
        string[] header = tfp.ReadFields();
    
        // Read rows from file
    	// For debugging limit the row count
    	//int maxrows = 10;
    	int maxrows = int.MaxValue;
    	int rowcount = 0;
    	string term = "";
        while (!tfp.EndOfData && rowcount < maxrows)
        {
            // Read row of data from the file
            string[] row = tfp.ReadFields();
    		rowcount ++;
    
    		// Add "," on all but last line
    		term = tfp.EndOfData || rowcount >= maxrows ? "" : ",";
    
            // Add new item from row data
    #>
    				new ISO_639_3 { Id = "<#=row[0]#>", Part2B = "<#=row[1]#>", Part2T = "<#=row[2]#>", Part1 = "<#=row[3]#>", Scope = "<#=row[4]#>", Language_Type = "<#=row[5]#>", Ref_Name = "<#=row[6]#>", Comment = "<#=row[7]#>" }<#=term#>
    <# 
    	} 
    #>  
    			};
    			return list;
    		}
    
    	}
    
    }
