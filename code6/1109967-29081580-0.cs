    class ProjectItemMock : ProjectItem{
    	public bool SaveAs(string newFilename) { return false;}
    	public EnvDTE.Window Open(string name) { return null;}
    	public void Remove() {}
    	public void ExpandView(){}
    	public void Save(string filename){}
    	public void Delete(){}
    	public bool IsDirty {get;set;}
    	public string get_FileNames(short index) {return "test";}
    	public short FileCount {get;set;}
    	public string Name{get;set;}
    	public string Kind { get; set; }
    	public EnvDTE.ProjectItems Collection {get;set;}
    	public EnvDTE.Properties Properties {get;set;}
    	public EnvDTE.DTE DTE{get;set;}
    	public EnvDTE.ProjectItems ProjectItems { get; set; }
    	public bool get_IsOpen(string s) { return false;}
    	public object Object { get; set; }
    	public object get_Extender(string s) {return null;}
    	public object ExtenderNames { get; set; }
    	public string ExtenderCATID { get; set; }
    	public bool Saved { get; set; }
    	public EnvDTE.ConfigurationManager ConfigurationManager { get; set; }
    	public EnvDTE.FileCodeModel FileCodeModel { get; set; }
    	public EnvDTE.Document Document { get; set; }
    	public EnvDTE.Project SubProject { get; set; }
    	public EnvDTE.Project ContainingProject { get; set; }
    }
