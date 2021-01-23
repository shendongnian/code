    private static IEnumerable<SelectListItem> GetProductTypes()
    {
        var filter = new System.Text.RegularExpressions.Regex("Prodcut1|Prodcut2|Prodcut3");
        return from ProdType e in Enum.GetValues(typeof(ProdType))
               where filter.IsMatch(e.ToString())
               select new SelectListItem 
                   {
                       Value = ((int)e).ToString(), 
                       Text = e.ToString() 
                    };
    }
