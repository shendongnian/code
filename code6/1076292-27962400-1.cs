    <#@ template language="C#" hostspecific="True" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Runtime.Remoting.Messaging" #>
    <#@ import namespace="Microsoft.VisualStudio.TextTemplating" #>
    <#
      CallContext.LogicalSetData("ClassName", "TestClass");
      string output = ProcessTemplate("Template.tt");
      Write(output);
    #>
    <#+
      string ProcessTemplate(string templateFileName)
      {
        string template = File.ReadAllText(Host.ResolvePath(templateFileName));
        Engine engine = new Engine();
        return engine.ProcessTemplate(template, Host);
      }
    #>
