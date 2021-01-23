    private static IEnumerable<Form> LoadFormsFromAssembly(string fileName)
    {
        Assembly asm = Assembly.LoadFrom(fileName);
        foreach (Type type in asm.GetExportedTypes()) {
            if (typeof(Form).IsAssignableFrom(type) &&
               (type.Attributes & TypeAttributes.Abstract) != TypeAttributes.Abstract) {
                Form form = (Form)Activator.CreateInstance(type);
                yield return form;
            }
        }
    }
