    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ output extension=".generated.cs" #>
    <#@ import namespace="System.IO" #>
    namespace MyProject.Constants {
    
        /// <summary>
        /// Contains the names of the stored procedures of the application
        /// </summary>
        public static class StoredProceduresNames 
    	{
    <# 
    	string storedProceduresFolder = "Stored Procedures"; //set the path to sp folder here...
    	string[] fileArray = Directory.GetFiles(Host.ResolvePath(storedProceduresFolder));
    	foreach(var filePath in fileArray){
    		string spName = Path.GetFileName(filePath).ToUpper().Replace(".SQL", "");		
    #>
            public const string <#= spName #> = "<#= spName #>";
    <#
            }
     #>
        }
    }
