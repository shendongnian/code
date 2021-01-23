        public static Dictionary<string, string> GetProperties<T>(params string[] propNames)
        {
            PropertyInfo[] resultcontactproperties  = null;
            if(propNames.Length > 0)
            {
                resultcontactproperties = typeof(T).GetProperties().Where(p => propNames.Contains(p.Name)).ToArray();
            }
            else
	        {
                resultcontactproperties = typeof(T).GetProperties();
	        }
            var dict = resultcontactproperties.ToDictionary(propInfo => propInfo.Name, propInfo => propInfo.Name);
            return dict;
        }  
     @Html.DropDownListFor(m=>m.properties, new SelectList(
     Entity.Data.ContactManager.GetProperties<Contact>(),"Key","Value"), 
     "Select a Property")
