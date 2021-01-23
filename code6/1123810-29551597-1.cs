    type.Members.Insert(0, GenerateTypeWithoutEmptyLines(@struct));
    
...
    /// <summary>
    /// Removes the blank lines spaces by generating the code as a string without BlankLinesBetweenMembers
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns></returns>
    private static CodeSnippetTypeMember GenerateTypeWithoutEmptyLines(CodeTypeDeclaration type)
    {
        var provider = CodeDomProvider.CreateProvider("CSharp");
        using (var sourceWriter = new StringWriter())
        using (var tabbedWriter = new IndentedTextWriter(sourceWriter, "\t"))
        {
            tabbedWriter.Indent = 2;
            provider.GenerateCodeFromType(type, tabbedWriter, new CodeGeneratorOptions()
            {
                BracingStyle = "C",
                IndentString = "\t",
                BlankLinesBetweenMembers = false
            });
            return new CodeSnippetTypeMember("\t\t" + sourceWriter);
        }
    }
