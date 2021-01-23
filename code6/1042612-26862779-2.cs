    public static System.Web.Mvc.SelectList ToSelectList<TEnum>(this TEnum obj) where TEnum : struct, IComparable, IFormattable, IConvertible
    {
                                                       
      return new SelectList(Enum.GetValues(typeof(TEnum))
                                          .OfType<Enum>()
                                          .Select(x =>
                                          new SelectListItem
                                             {
                                              Text = (Convert.ToInt32(x)).ToString(),
                                              Value = Enum.GetName(typeof(TEnum),x)
                                             }
                                             ),"Value","Text");
    }
