    public enum ReportIDs
    {
        [Description("REPORTNAME_ONE")]
        ReportOne=10001,
        [Description("REPORTNAME_TWO")]
        ReportTwo=10002,
        [Description("REPORTNAME_THREE")]
        ReportThree=10003,
    }
    static class Program
    {
        static void Main(string[] args)
        {
            // Make list of names
            var reports=new List<string>(new string[] { "REPORTNAME_ONE", "REPORTNAME_THREE" });
            // Get a list of enum values
            var ids=reports.Select((rpt) => rpt.GetEnumFromDescription<ReportIDs>()).ToList();
        }
        /// <summary>
        /// Retrieve the description on the enum, e.g.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// Then when you pass in the enum, it will retrieve the description
        /// </summary>
        /// <param name="en">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public static string GetDescriptionFromEnum(this Enum en)
        {
            Type type=en.GetType();
            MemberInfo[] memInfo=type.GetMember(en.ToString());
            if(memInfo!=null&&memInfo.Length>0)
            {
                object[] attrs=memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if(attrs!=null&&attrs.Length>0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }
        /// <summary>
        /// Retrieve the enum value of type T with specified description
        /// </summary>
        /// <typeparam name="T">The enum type to look into</typeparam>
        /// <param name="description">The description to look for</param>
        /// <returns>Either the enum value, or default(T)</returns>
        public static T GetEnumFromDescription<T>(this string description)
            where T: struct, IComparable
        {
            Type type=typeof(T);
            T[] members=type.GetEnumValues().Cast<T>().ToArray();
            for(int i=0; i<members.Length; i++)
            {
                var descr=GetDescriptionFromEnum(members[i] as Enum);
                if(description.Equals(descr))
                {
                    return members[i];
                }
            }
            return default(T);
        }
    }
