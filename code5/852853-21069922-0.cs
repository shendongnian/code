    <#@ template debug="true" hostSpecific="true" #>
    <#@ output extension=".generated.cs" #>
    <#@ Assembly Name="EnvDTE" #>
    <#@ Assembly Name="System.Data" #>
    <#@ Assembly Name="$(SolutionDir)Services.Entities\bin\DevTest\Libraries.DB.dll" #> **// * custom location for custom libraries**
    <#@ Assembly Name="$(SolutionDir)Services.Entities\bin\DevTest\MySql.Data.dll" #> **// custom location for custom libraries**
    <#@ import namespace="EnvDTE" #>
    <#@ import namespace="System.Data" #>
    <#@ import namespace="System.Data.SqlClient" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Text.RegularExpressions" #>
    
    <#
    		string tableName = "";
    		//string path = Path.GetDirectoryName(Host.TemplateFile);
    		string connectionString = "mysqlConnectionString"; **// replaced with regular value, could pull from web.config but it's only updated rarely**
    
    		// Get containing project
    		IServiceProvider serviceProvider = (IServiceProvider)Host;
    		DTE dte = (DTE)serviceProvider.GetService(typeof(DTE));
    		//Project project = dte.Solution.FindProjectItem(Host.TemplateFile).ContainingProject;
    #>
    using System;
    using System.CodeDom.Compiler;
    
    namespace Services.Entities
    {
    	[GeneratedCode("TextTemplatingFileGenerator", "10")]
    	public enum Store
    	{
    <#
    	  
        using (var cmd = new Libraries.DB.Mysql.Command(connectionString)) **//Custom libraries to open a disposable command object**
        {
          cmd.Clear();
          cmd.AppendCmd("select id, storecode, StoreName \n");
          cmd.AppendCmd("from stores \n");
    		
          var reader = cmd.ExecuteReader();
    		  while(reader.Read())
    		  {
              int storeId = Convert.ToInt32(reader["id"]);
    	      string storecode = reader["storecode"].ToString();
    	      string description = reader["StoreName"].ToString();
    #> //We now have the data, let's use it!  The code in <#= gets populated #>**
        [Libraries.Utils.Enums.Info(Code = "<#= storecode #>", Name = "<#= description #>")] <#= Sanitize(description) #> = <#= storeId #>,
    <#
    		  }
        }
    #>	
      }
    }
    //This is a method which takes a name like "Some Descripton" and Sanitizes it to Some_Description so it can be usable as an enum**
    <#+
    		static string Sanitize(string token) 
    		{
    				// Replace all invalid chars by underscores
    				token = Regex.Replace(token, @"[\W\b]", "_", RegexOptions.IgnoreCase);
    
    				// If it starts with a digit, prefix it with an underscore
    				token = Regex.Replace(token, @"^\d", @"_$0");
    
    				// Check for reserved words
    				// TODO: Clean this up and add other reserved words (keywords, etc)
    				if (token == "Url") token = "_Url";
    
    				return token;
    		}
    #>
