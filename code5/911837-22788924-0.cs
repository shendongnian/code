    protected void Page_Load(object sender, eventArgs e){
        var data = Item_Getall(); //Creates a list of items by calling your method.
        
        gridView.DataSource = data; //assuming the ID of your gridview is "gridView". It might be something different.
        gridView.DataBind(); //binds the data to your grid. If you have it set to auto populate, it should essentially list out every public property for each object in the list.
    }
 
