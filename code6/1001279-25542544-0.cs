    public string Compile<T>(string viewContent, T model)
    {
        return Razor.Parse(viewContent, model);
    }
    public string CompileFromPath<T>(string viewPath, T model)
    {
        if (!File.FileExists(viewPath))
        {
            return null;
        }
    
        var viewContent = File.ReadAllText(viewPath, System.Text.Encoding.UTF8);
    
        return this.Compile(viewContent, model);
    }
