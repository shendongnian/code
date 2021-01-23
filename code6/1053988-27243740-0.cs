    DataTable fav1;
    fav1= ThreeColumntable.Copy();
    fav1.Columns.Remove("Favourite2");
    fav1.Columns[1].ColumnName = "Favourites";
    
    DataTable fav2;
    fav2= ThreeColumntable.Copy();
    fav2.Columns.Remove("Favourite1");
    fav2.Columns[1].ColumnName = "Favourites";
    
    var result = fav1.AsEnumerable()
                .Union(fav2.AsEnumerable());
