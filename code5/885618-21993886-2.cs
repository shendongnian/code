    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EditorControlAttribute : Attribute
    {
        private readonly Type type;
        public Type EditorType
        {
            get { return type; }
        }
        public EditorControlAttribute(Type type)
        {
            this.type = type;
        }
    }
    public sealed class OptionsGrid
    {
        [Description("Teststring"), DisplayName("DisplaynameTest"), Category("Test")]
        [EditorControl(typeof(RepositoryItemMemoEdit))]
        public string Test { get; set; }
    }
