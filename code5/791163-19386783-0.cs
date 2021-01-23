    public static class ReusableMethods
    {
        public static Expression<Func<int, Person>> GetAge()
        {
            return p => p.Age;
        }
    }
    
    var getAge = ReusableMethods.GetAge();
    var ageQuery = from p in People.AsExpandable()
                   select getAge.Invoke(p);
