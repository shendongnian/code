    [ComVisible(true)]
    // TODO: Replace with your GUID
    [Guid("24BCC6BC-D53F-497B-8455-0BE15568E6B3")]
    [GPFToolAttribute("GPFEnumGenerator", "Generate an Enum conatins all the keys of a GPF Dictionary.")]
    public class GPFEnumGenerator : BaseCodeGeneratorWithSite
    {
     
        #region BaseCode generator methods
        public override string GetDefaultExtension()
        {
            // TODO: Replace with your implementation
            return ".cs";
        }
        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
           
                 string generatedCode = "Your code here";
                return Encoding.UTF8.GetBytes(generatedCode);
            }
        }
        #endregion 
        #region Registration
        [ComRegisterFunction]
        public static void RegisterClass(Type t)
        {
            GuidAttribute guidAttribute = getGuidAttribute(t);
            GPFToolAttribute customToolAttribute = getCustomToolAttribute(t);
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(
              GetKeyName(CSharpCategoryGuid, customToolAttribute.Name)))
            {
                key.SetValue("", customToolAttribute.Description);
                key.SetValue("CLSID", "{" + guidAttribute.Value + "}");
                key.SetValue("GeneratesDesignTimeSource", 1);
            }
        }
        [ComUnregisterFunction]
        public static void UnregisterClass(Type t)
        {
            GPFToolAttribute customToolAttribute = getCustomToolAttribute(t);
            Registry.LocalMachine.DeleteSubKey(GetKeyName(
              CSharpCategoryGuid, customToolAttribute.Name), false);
        }
        internal static GuidAttribute getGuidAttribute(Type t)
        {
            return (GuidAttribute)getAttribute(t, typeof(GuidAttribute));
        }
        internal static GPFToolAttribute getCustomToolAttribute(Type t)
        {
            return (GPFToolAttribute)getAttribute(t, typeof(GPFToolAttribute));
        }
        internal static Attribute getAttribute(Type t, Type attributeType)
        {
            object[] attributes = t.GetCustomAttributes(attributeType, /* inherit */ true);
            if (attributes.Length == 0)
                throw new Exception(
                  String.Format("Class '{0}' does not provide a '{1}' attribute.",
                  t.FullName, attributeType.FullName));
            return (Attribute)attributes[0];
        }
        internal static string GetKeyName(Guid categoryGuid, string toolName)
        {
            return
              String.Format("SOFTWARE\\Microsoft\\VisualStudio\\" + VisualStudioVersion +
                "\\Generators\\{{{0}}}\\{1}\\", categoryGuid, toolName);
        }
        #region Properties
        internal static Guid CSharpCategoryGuid = new Guid("FAE04EC1-301F-11D3-BF4B-00C04F79EFBC");
        private const string VisualStudioVersion = "12.0";
        #endregion // Properties
        #endregion Registration
    }
