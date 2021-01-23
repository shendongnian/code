    public class TenantViewModel
    {
       public string ID {get; set;}
       public string Name {get; set;}
    }
    int numberOfTenantsPossible = Space.MaxNumberOfTenants - (Space.MaleHousemates + Space.FemaleHousemates);
    var vms = new List<TenantViewModel>();
    for (int itemCount = 0; itemCount < numberOfTenantsPossible; itemCount++ )
    {
        var vm = new TenantViewModel { ID = (itemCount + 1).ToString(), Name = (itemCount + 1).ToString() + " tenants"};
        vms.Add(vm);
    }
    ulNumTenants.DataSource = vms;
    ulNumTenants.DataBind();
