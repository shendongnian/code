    StringBuilder codeBuilder = new StringBuilder();
    foreach (var item in controllerChecked)
    {
        string propertyName = item.Name.SubString(1);
        codeBuilder.AppendLine("[Dependency(\"" + item.Name + "\")]");
        codeBuilder.AppendLine("public " + item.Type + " " + propertyName + " { get; set; }");
        codeBuilder.AppendLine();
    }
    string code = codeBuilder.ToString();
