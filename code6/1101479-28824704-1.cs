    // in controller we'll pass the desired selected value to extension method:
    ViewBag.EnumList = Patient.PaymentType.Insurer.ToSelectList(Patient.PaymentType.Insurer);
    
    // update method to support this parameter
    public static System.Web.Mvc.SelectList ToSelectList<TEnum>(this TEnum obj, object selectedValue)
            where TEnum : struct, IComparable, IFormattable, IConvertible // correct one
        {
            return new SelectList(
                Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                     .Select(x =>
                         new SelectListItem
                         {
                             Text = Enum.GetName(typeof(TEnum), x),
                             Value = (Convert.ToInt32(x)).ToString()
                         }
                     ) 
                ,"Value", "Text"
                ,(int)selectedValue); // pass selected value to SelectList constructor
    
        }
