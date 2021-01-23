    public class PersonFinder
    {
        public Person FindPersonByLocation(Place placeToSearch)
        {
            using (var db = new ???)
            {
                return db.People.SingleOrDefault(p => p.Location_Id == placeToSearch.Id);
            }
        }
    }
