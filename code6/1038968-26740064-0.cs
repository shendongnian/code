    namespace MyCompany.MyApplication.ReportingClasses
    {
    public interface IReporting
    {
        string HTMLReportString {get;}    
    }
    
    public class ReportingClassName : IReporting
    {
        public string HTMLReportString {get; private set;}
    
        ReportingClassName()
        {
            // Use linq to generate report;
            // Populate gridview, pass object to function which returns HTMLString;
            // set HTMLReportString property;
        }
    
    }
    }
    
    
    string myAssembly = "AssemblyName"; // This is static;
    string myClass = "AssemblyQualifiedName"; // This value from DDL;
    var myObject = Activator.CreateInstance(AssemblyName, AssemblyQualifiedName);
    
    string propertyValue = ((IReporting)myObject).HTMLReportString; // Thanks to the interface, myObject provides HTMLReportString and it doesn't need reflection neither "dynamic".
    
    "UpdatePanelID".InnerHTML = propertyValue;
