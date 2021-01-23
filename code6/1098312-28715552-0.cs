    public static List<EnumModel> GetEnumList<T>()
                {
                    var enumValues = Enum.GetValues(typeof(T)).Cast<T>().Select(rentalType => new EnumModel()
                    {
                        Value = Convert.ToInt32(rentalType),
                        Name = GetDisplayName<T>(rentalType, false)
                    }).ToList();
        
                    return enumValues;
                }
                
                public static string GetDisplayName<T>(T value, bool isDisplayName)
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("value", "Enum value Empty");
                    }
        
                    var type = value.GetType();
                    var field = type.GetField(value.ToString());
                    if (field == null)
                    {
                        return value.ToString();
                    }
        
                    var attributes = ((DisplayAttribute[])field.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();
                    return attributes != null ? isDisplayName == true ? attributes.GetDescription() : attributes.Description : value.ToString();
                }
        
         public class EnumModel
                {
                    /// <summary>
                    /// Gets or sets the value
                    /// </summary>
                    public int Value { get; set; }
        
                    /// <summary>
                    /// Gets or sets the name
                    /// </summary>
                    public string Name { get; set; }
                }
