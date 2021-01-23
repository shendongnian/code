    class HorseRepo : BaseRepo<Horse>
    {
        // This will of course be some data source
        protected override IQueryable<Horse> Entities
        {
            get
            {
                return new List<Horse> {
		            new Horse { Id = 1, Name = "Mr Horse", Color = "Brown" },
		            new Horse { Id = 2, Name = "Mrs Horse", Color = "White" },
		            new Horse { Id = 3, Name = "Jr Horse", Color = "White" },
		            new Horse { Id = 4, Name = "Sr Horse", Color = "Black" },
		            new Horse { Id = 5, Name = "Dr Horse", Color = "Brown" },
	            }.AsQueryable();
            }
        }
 
        // This is what I think you should expose to the application
        // This is the usage of the expression fest above.
        public IEnumerable<GroupedHorses> GetGroupedByColor() {
            return horseRepo.GetAllPaged(
                new List<Expression<Func<Horse, bool>>> {
                    h => h.Name != string.Empty, 
                    h => h.Id > 0
                },
                h => new HorseShape { Id = h.Id, Name = h.Name, Color = h.Color },
                hs => hs.Name,
                hs => hs.Color,
                g => new GroupedHorses
                {
                    Color = g.Key,
                    Horses = g.ToList()
                }
            );
        }
    }
