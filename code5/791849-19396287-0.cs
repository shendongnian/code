    public static Dictionary<string, string> GetProperties<T>()
        {
            PropertyInfo[] resultprops = typeof(T).GetProperties();
            var dict = resultprops.ToDictionary(propInfo => propInfo.Name, propInfo => propInfo.Name);
            return dict;
        }  
     @Html.DropDownListFor(m=>m.properties, new SelectList(
     Entity.Data.ContactManager.GetProperties<Contact>(),"Key","Value"), 
     "Select a Property")
