	<#@ template language="C#" debug="true" hostSpecific="true" #>
	<#@ output extension=".cs" #>
	<#@ Assembly Name="System.Core.dll" #>
	<#@ Assembly Name="System.Xml.dll" #>
	<#@ Assembly Name="System.Xml.Linq.dll" #>
	<#@ Assembly Name="System.Windows.Forms.dll" #>
	<#@ Assembly name="EnvDTE" #>
	<#@ import namespace="EnvDTE" #>
	<#@ import namespace="System" #>
	<#@ import namespace="System.IO" #>
	<#@ import namespace="System.Diagnostics" #>
	<#@ import namespace="System.Linq" #>
	<#@ import namespace="System.Xml.Linq" #>
	<#@ import namespace="System.Collections" #>
	<#@ import namespace="System.Collections.Generic" #> 
	<#@ import namespace="System.Reflection" #>
	<#@ import namespace="System.Text" #>
	<#@ import namespace="System.Runtime.Serialization" #>
	<#@ import namespace="XXXXXXXXXXX" #>
	<#@ import namespace="System.Runtime.Serialization" #>
	<#@ Assembly Name="$(ProjectDir)\bin\$(ConfigurationName)\FicheSignaletiqueViseoData.dll" #>
	// T4Class : Génération des accesseurs de toutes les classes de FicheSignaletiqueViseoData
	// pour les types non génériques et les classes, on rajoute une protection contre le null
	// pour les String, on rajoute une protection contre le null et un Trim automatique
	// Date de génération : <#= System.DateTime.Now.ToString() #>
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	<#   
		const String BusinessEntityNamespace= "XXXXXXXXXXX";
		WriteLine("namespace {0}", BusinessEntityNamespace);
		WriteLine("{");
		PushIndent("\t");
		String T4TemplatePath = Path.GetDirectoryName(Host.TemplateFile);
		String dataContractSource = Path.Combine(T4TemplatePath, "DataContract");
		String[] sources = Directory.GetFiles(dataContractSource, "*.cs");
		IServiceProvider hostServiceProvider = (IServiceProvider)Host;
		EnvDTE.DTE dte = (EnvDTE.DTE)hostServiceProvider.GetService(typeof(EnvDTE.DTE));
		foreach(string file in sources)
		{
			EnvDTE.ProjectItem projectItem = dte.Solution.FindProjectItem(file);
			FileCodeModel fileCodeModel = projectItem.FileCodeModel;
			if (fileCodeModel != null)
			{
				foreach (CodeElement codeElement in fileCodeModel.CodeElements)
				{
					if (codeElement is CodeNamespace)
					{
						CodeNamespace nsp = codeElement as CodeNamespace;
						foreach (CodeElement subElement in nsp.Children)
						{
							if (subElement is CodeClass)
							{
								CodeClass classe = subElement as CodeClass;
								if (classe.Access == vsCMAccess.vsCMAccessPublic && classe.Name.StartsWith("T4") == false && classe.Name != "Important")
								{
									GenerateClassFromCode(classe);
								}
							}
						}
					}
				}
			}
		}
		 
		PopIndent();
		WriteLine("}");
	#>
 
	<#+  
		private void GenerateClassFromCode(CodeClass classToGenerate)
		{
			WriteLine("[DataContract]");
			WriteLine("public partial class {0} : IExtensibleDataObject", classToGenerate.Name);
			WriteLine("{");
			PushIndent("\t");
			WriteLine("private ExtensionDataObject extensionDataObjectValue;");
			WriteLine(String.Empty);
			WriteLine("public ExtensionDataObject ExtensionData");
			WriteLine("{");
			PushIndent("\t");
			WriteLine("get { return this.extensionDataObjectValue; }");
			WriteLine("set { this.extensionDataObjectValue = value; }");
			PopIndent();
			WriteLine("}");	
			WriteLine(String.Empty);
			List<Tuple<string, Int16>> checkOrder = new List<Tuple<string, Int16>>();
			List<CodeVariable> listVariable = new List<CodeVariable>();
			List<CodeEnum> listEnum = new List<CodeEnum>();
			foreach (CodeElement elem in classToGenerate.Members)
			{
				if (elem is CodeVariable)
				{
					listVariable.Add(elem as CodeVariable);
				}
				if (elem is CodeEnum)
				{
					listEnum.Add(elem as CodeEnum);
				}
			}
			foreach(CodeVariable variable in listVariable)
			{
				if (variable.Access == vsCMAccess.vsCMAccessPrivate)
				{
					// attributs
					foreach (CodeAttribute attribut in variable.Attributes)
					{
						Int16 order = getPropertyOrderFromCode(attribut);
						if (order >= 0)
						{
							if (checkOrder.Where(c => c.Item2 == order).Count() > 0)
							{
								WriteLine("// Ci dessous, erreur de compilation voulue. Veuillez corriger et recompiler.");
								WriteLine("ERROR : Dans la classe " + classToGenerate.Name + ", doublon sur le T4Order " + order + " (utilisé par " + checkOrder.Where(c => c.Item2 == order).First().Item1 + ")");
							}
							else
							{
								WriteLine("[DataMember(Order = {0})]", order);
								checkOrder.Add(new Tuple<string, Int16>(variable.Name, order));
							}
						}
						else
						{
							Write("[" + attribut.FullName);
							if(attribut.Children != null && attribut.Children.Count > 0)
							{
								TextPoint start = attribut.Children.Cast<CodeElement>().First().GetStartPoint();
								TextPoint finish = attribut.GetEndPoint();
								String allArguments = start.CreateEditPoint().GetText(finish);
								Write("(" + allArguments);
							}
							WriteLine("]");   
						}                   
					}
					// variable
					string propertyTypeStr = variable.Type.AsFullName;
					Type type = Type.GetType(propertyTypeStr);
					WriteLine("public {0} {1}", propertyTypeStr, MakeUpper(variable.Name));
					WriteLine("{");
					PushIndent("\t");
						// getter
						WriteLine("get ");
						WriteLine("{");
						PushIndent("\t");
							if (propertyTypeStr == "System.String")
							{
								WriteLine("return this.{0} == null ? String.Empty : this.{0}.Trim();", variable.Name, propertyTypeStr);
							}
							else if (listEnum.Select(e => e.FullName).Contains(propertyTypeStr))
							{
								WriteLine("return this.{0};", variable.Name);
							}
							else if (type == null || ((type.IsGenericType || type.IsClass)))
							{
								WriteLine("return this.{0} ?? new {1}();", variable.Name, propertyTypeStr);
							}
							else
							{
								WriteLine("return this.{0};", variable.Name);
							}
						PopIndent();
						WriteLine("}");		
						WriteLine(String.Empty);
						// setter
						WriteLine("set ");
						WriteLine("{");
						PushIndent("\t");
							WriteLine("this.{0} = value;", variable.Name);
						PopIndent();
						WriteLine("}");	
					PopIndent();
					WriteLine("}");	
					WriteLine(String.Empty);
				}
			}
	
			PopIndent();
			WriteLine("}");
			WriteLine(String.Empty);
		}
		private Int16 getPropertyOrderFromCode(CodeAttribute member)
		{
			if (member != null)
			{
				if (member.FullName == typeof(T4Order).ToString())
				{
					return Convert.ToInt16(member.Value);
				}
			}
			return -1;
		}
		private String MakeUpper(String name)
		{
			return name.Substring(0, 1).ToUpper() + name.Substring(1, name.Length-1);
		}
	#>
