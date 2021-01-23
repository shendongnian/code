    <ComboBox Width="200" Height="25" ItemsSource="{Binding ComboSource}"
              DisplayMemberPath="Value"
              SelectedValuePath="Key"/>
 
    public class MainViewModel
    {
        public List<KeyValuePair<Status, string>> ComboSource { get; set; }
    
        public MainViewModel()
        {
            ComboSource = new List<KeyValuePair<Status, string>>();
            Status st=Status.Open;
            ComboSource = re.GetValuesForComboBox<Status>();
        }
    }
    
    public enum Status
    {
        [Description("Open")]
        Open,
        [Description("Closed")]
        Closed,
        [Description("InProgress")]
        InProgress
    }
    
     public static class ExtensionMethods
        {
            public static List<KeyValuePair<T, string>> GetValuesForComboBox<T>(this Enum theEnum)
            {
                List<KeyValuePair<T, string>> _comboBoxItemSource = null;
                if (_comboBoxItemSource == null)
                {
                    _comboBoxItemSource = new List<KeyValuePair<T, string>>();
                    foreach (T level in Enum.GetValues(typeof(T)))
                    {
                        string Description = string.Empty;
                        FieldInfo fieldInfo = level.GetType().GetField(level.ToString());
                        DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (attributes != null && attributes.Length > 0)
                        {
                            Description = GetDataFromResourceFile(attributes.FirstOrDefault().Description);
                        }
                        KeyValuePair<T, string> TypeKeyValue = new KeyValuePair<T, string>(level, Description);
                        _comboBoxItemSource.Add(TypeKeyValue);
                    }
                }
                return _comboBoxItemSource;
            }
    
            public static string GetDataFromResourceFile(string key)
            {
                //Do you logic to get from resource file based on key for a language.
            }
        }
