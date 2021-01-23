    public class InformationListener : DefaultEvents
    {
        public override void OnInformation(DtsObject source, int informationCode, string subComponent, string description, string helpFile, int helpContext, string idofInterfaceWithError, ref bool fireAgain)
        {
            //base.OnInformation(source, informationCode, subComponent, description, helpFile, helpContext, idofInterfaceWithError, ref fireAgain);
            Console.WriteLine(string.Format("{0} {1}", subComponent, description));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePackage = string.Empty;
            string path = string.Empty;
            string variableName = string.Empty;
            string designValue = string.Empty;
            string newValue = string.Empty;
            InformationListener listener = null;
            sourcePackage = @"J:\Src\SO\SSIS\Package.dtsx";
            path = @"J:\runtime";
            variableName = "User::FolderPath";
            listener = new InformationListener();
            Application app = new Application();
            Package pkg = null;
            Variable ssisVariable = null;
            pkg = app.LoadPackage(sourcePackage, null);
            ssisVariable = pkg.Variables[variableName];
            designValue = ssisVariable.Value.ToString();
            Console.WriteLine(string.Format("Designtime value = {0}", designValue));
            ssisVariable.Value = path;
            newValue = ssisVariable.Value.ToString();
            Console.WriteLine(string.Format("new value = {0}", newValue));
            DTSExecResult results = DTSExecResult.Canceled;
            results = pkg.Execute(null, null, listener, null, null);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            
        }
    }
