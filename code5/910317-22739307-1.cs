    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.IO;
    using System.Reflection;
    using System.Text;
    
    namespace TTTTTest
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                new Program();
            }
    
            public Program()
            {
                // Create namespace
                var myNs = new CodeNamespace("MyNamespace");
                myNs.Imports.AddRange(new[]
                {
                    new CodeNamespaceImport("System"),
                    new CodeNamespaceImport("System.Text")
                });
    
                // Create class
                var myClass = new CodeTypeDeclaration("MyClass")
                {
                    TypeAttributes = TypeAttributes.Public
                };
    
                // Add properties to class
                var interfaceToUse = typeof (ISample);
                foreach (var prop in interfaceToUse.GetProperties())
                {
                    ImplementProperties(ref myClass, prop);
                }
    
                // Add class to namespace
                myNs.Types.Add(myClass);
    
                Console.WriteLine(GenerateCode(myNs));
                Console.ReadKey();
            }
    
            private string GenerateCode(CodeNamespace ns)
            {
                var options = new CodeGeneratorOptions
                {
                    BracingStyle = "C",
                    IndentString = "    ",
                    BlankLinesBetweenMembers = false
                };
    
                var sb = new StringBuilder();
                using (var writer = new StringWriter(sb))
                {
                    CodeDomProvider.CreateProvider("C#").GenerateCodeFromNamespace(ns, writer, options);
                }
    
                return sb.ToString();
            }
    
            private void ImplementProperties(ref CodeTypeDeclaration myClass, PropertyInfo property)
            {
                // Add private backing field
                var backingField = new CodeMemberField(property.PropertyType, GetBackingFieldName(property.Name))
                {
                    Attributes = MemberAttributes.Private
                };
    
                // Add new property
                var newProperty = new CodeMemberProperty
                {
                    Attributes = MemberAttributes.Public | MemberAttributes.Final,
                    Type = new CodeTypeReference(property.PropertyType),
                    Name = property.Name
                };
    
                // Get reference to backing field
                var backingRef = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), backingField.Name);
    
                // Add statement to getter
                newProperty.GetStatements.Add(new CodeMethodReturnStatement(backingRef));
    
                // Add statement to setter
                newProperty.SetStatements.Add(
                    new CodeAssignStatement(
                        new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), backingField.Name),
                        new CodePropertySetValueReferenceExpression()));
    
                // Add members to class
                myClass.Members.Add(backingField);
                myClass.Members.Add(newProperty);
            }
    
            private string GetBackingFieldName(string name)
            {
                return "_" + name.Substring(0, 1).ToLower() + name.Substring(1);
            }
        }
    
        internal interface ISample
        {
            int SampleID { get; set; }
            string SampleName { get; set; }
        }
    }
