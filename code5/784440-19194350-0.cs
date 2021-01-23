    public interface IHouseholdRepository : IDisposable
    {
        IEnumerable<tHousehold> Get();
        tHousehold GetById(int Id);
        IEnumerable<SelectListItem> AddHousingType();
        IEnumerable<SelectListItem> EditHousingType(int id);
        //etc...
    
    }
