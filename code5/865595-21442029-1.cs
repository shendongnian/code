    public class EnumConverter: IValueConverter{
        public Dictionary<ExpiryOptions, string> localizedValues = new Dictionary<ExpiryOptions, string>();
    
        public EnumConverter(){
            foreach(ExpiryOptionsvalue in Enum.GetValues(typeof(ExpiryOptions)))
            {
                 var localizedResources = typeof(Resources).GetProperties(BindingFlags.Static).Where(p=>p.Name.StartsWith("ExpiryOptions"));
                 string localizedString = localizedResources.Single(p=>p.Name="ExpiryOptions"+value).GetValue(null, null) as string;
                 localizedValues.Add(value, localizedString);
            }
        }
        public void Convert(...){
            return localizedValues[(ExpiryOptions)value];
        }
    }
