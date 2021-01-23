    public static class EnumExtension
    {
        public static string GetDescription(this System.Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }
    }
    
    public enum Category
    {
        [Description("TV Show")]
        TVShow,
    }
    @Html.ActionLink(item.Category.GetDescription(), "Category", new { id = item.Category })
