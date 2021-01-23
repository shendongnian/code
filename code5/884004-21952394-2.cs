    public class Model
    {
    public int SelectedItem{get;set;}
    public IList<DropDownObj> ListObj{get;set;
    public IList<SelectListItem> SelectListItemListObj{get;set;}
            {
                get
                {
                       var list = (from item in ListObj
                                select new SelectListItem()
                                {
                                    Text = item.Id.ToString(CultureInfo.InvariantCulture),
                                    Value item.Name
                                }).ToList();
                    return list;
                }
                set{}
            } 
    } 
    public class DropDownObj
    {
       public int Id{get;set;}
       public string Name{get;set;
    }
