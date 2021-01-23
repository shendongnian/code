    public class Repository : IRepository
    {
       public IEnumerable<Vehicle> FetchAllVehicles()
       {
          var vehicles = from v in db.Vehicles
                           from m in db.Makes
                           from mods in db.Models
                           where v.Model.ModelID == mods.ModelID
                           where mods.Make.MakeID == m.MakeID
                           select v;
    
            return vehicles.ToList();
       }
    }
