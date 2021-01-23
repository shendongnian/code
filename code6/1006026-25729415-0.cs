    public class HotelRepository : EFRepository<Hotel>, IHotelRepository
    {
         public List<IGrouping<string, Hotel>> GetAllByCountrynameOrderedByCountrynameAndGroupedByCategoryname(string categoryName, string countryName)
         {
              return DbSet
                  .Where(hotel => hotel.Country.Name.Equals(countryName))
                  .OrderByDescending(hotel => hotel.Rating)
                  .GroupBy(hotel => hotel.Category.Name)
                  .ToList();
         }
    }
