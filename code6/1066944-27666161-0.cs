    public class MyViewModelVM
    {
    	public SelectList Companies { get; set; }
    }
    
    MyEntities myEntities = new MyEntities();
    List<Company> companies = myEntities.Companies.ToList()
     .Select(n => new SelectList() {
          Id = n.Id,
          CompanyName = n.CompanyName
      };
