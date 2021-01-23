    public static System.Data.DataTable ListToDataTable<T>( object[] list )
    {
        ....
    }
    var dt = ListToDataTable( item.Cast<object>().ToArray() );
