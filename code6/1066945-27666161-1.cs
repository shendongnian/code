    public class MyViewModelVM
    {
    	public SelectList Companies { get; set; }
    }
    
    MyEntities myEntities = new MyEntities();
    List<Company> companies = myEntities.Companies.ToList();
    
    SelectList compList = new SelectList()
    foreach(var item in companies)
    {
       complist.Add(item[0], item[1]); //please take care of the proper syntax here.
      //or
       complist.Add(item.items[0], item.items[1].toString());
      //but this way you can add without hardcoding field names
    }
     
