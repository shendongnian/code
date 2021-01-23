    public static ISheet FindSheet( this IWorkbook wb, params string[] searches )
    {
        if( null == wb || null == searches ) { return null; }
    
        return wb.Where(sh => searches.All(sr => sh.FindCell(sr) != null))
                 .FirstOrDefault();
    }
