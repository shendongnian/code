    /// <summary>
    /// Class EnumExtenions
    /// </summary>
    public static class EnumExtenions
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>String.</returns>
        public static String GetDescription(this Enum e)
        {
            String enumAsString = e.ToString();
            Type type = e.GetType();
            MemberInfo[] members = type.GetMember(enumAsString);
            if (members != null && members.Length > 0)
            {
                Object[] attributes = members[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    enumAsString = ((DescriptionAttribute)attributes[0]).Description;
                }
            }
            return enumAsString;
        }
        /// <summary>
        /// Gets an enum from its description.
        /// </summary>
        /// <typeparam name="TEnum">The type of the T enum.</typeparam>
        /// <param name="description">The description.</param>
        /// <returns>Matching enum value.</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public static TEnum GetFromDescription<TEnum>(String description)
            where TEnum : struct, IConvertible // http://stackoverflow.com/a/79903/298053
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new InvalidOperationException();
            }
            foreach (FieldInfo field in typeof(TEnum).GetFields())
            {
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == description)
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
            }
            return default(TEnum);
        }
    }
