    public enum ReportGroup
    {
        [DescriptionAttribute("~/Content/StimulReports/MonthGroup.mrt")]
        Month,
        [DescriptionAttribute("~/Content/StimulReports/YearGroup.mrt")]
        Year
    }
    public static T GetAttribute<T>(this Enum e) where T : Attribute
    {
        System.Reflection.FieldInfo fi = e.GetType().GetField(e.ToString());
        object[] o = (object[])fi.GetCustomAttributes(typeof(T), false);
        return o.Length > 0 ? (T)o[0] : default(T);
    }
    public static void LoadStimulReports(ReportGroup reportGroup)
    {
        report.Load(Server.MapPath(reportGroup.GetAttribute<DescriptionAttribute>().Description));
    }
