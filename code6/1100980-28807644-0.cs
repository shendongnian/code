     public static System.Web.Mvc.SelectList ToSelectList<TEnum>(this TEnum obj)
                where TEnum : struct, IComparable, IFormattable, IConvertible // correct one
     {
    
       return new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                  .Select(x =>
                        new SelectListItem
                        {
                            Text = Enum.GetName(typeof(TEnum), x),
                            Value = (Convert.ToInt32(x)).ToString()
                        }), "Value", "Text");
    
    }
