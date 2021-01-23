    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ assembly name="Microsoft.CSharp.dll" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Text.RegularExpressions" #>
    <#@ import namespace="System.Reflection" #>
    <#@ output extension=".cs" #>
    
    <#
    		var assemblyVersionRegex = new Regex(@"AssemblyVersion\(\""(?<version>(.*?))\""\)");
    		var pathBase = new FileInfo(Host.TemplateFile).DirectoryName;
    		var assemblyInfoPath = Path.Combine(pathBase, @"Properties\AssemblyInfo.cs");
    
    		var assemblyInfoSources = File.ReadAllText(assemblyInfoPath);
    		var match = assemblyVersionRegex.Match(assemblyInfoSources);
    		var version = match.Success 
    				? match.Groups["version"].Value
    				: "unknow";
    #>
    
    public static class SomeAssemblyInfo
    {
    	public const string Version = "<#= version #>";
    }
