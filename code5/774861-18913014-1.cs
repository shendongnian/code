    public static string GetDescriptionFromEnumValue(Enum value)
        {
            DisplayAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute ), false)
                .SingleOrDefault() as DisplayAttribute ;
            return attribute == null ? value.ToString() : attribute.Description;
        }
