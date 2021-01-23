    <ComboBox Width="200" Height="25" ItemsSource="{Binding ComboSource}"
                  DisplayMemberPath="Value"
                  SelectedValuePath="Key"/>
     public class MainViewModel
    {
        public List<KeyValuePair<RentStatus, string>> ComboSource { get; set; }
        public MainViewModel()
        {
            ComboSource = new List<KeyValuePair<RentStatus, string>>();
            RentStatus re=RentStatus.Active;
            ComboSource = re.GetValuesForComboBox<RentStatus>();
        }
    }
    public enum RentStatus
    {
        [Description("Preparation description")]
        Preparation,
        [Description("Active description")]
        Active,
        [Description("Rented to people")]
        Rented
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
                        Description = attributes.FirstOrDefault().Description;
                    }
                    KeyValuePair<T, string> TypeKeyValue = new KeyValuePair<T, string>(level, Description);
                    _comboBoxItemSource.Add(TypeKeyValue);
                }
            }
            return _comboBoxItemSource;
        }
    }
