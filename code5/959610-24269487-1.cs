    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyBuildSystem : System.Attribute
    {
        private string _strBuildSystemName;
        public AssemblyBuildSystem(string buildSystemName)
        {
            _strBuildSystemName = buildSystemName;
        }
        public BuildSystemName { get { return _strBuildSystemName; } }
    }
