        public static class Extensions
        {
            public static IEnumerable<IAuditable> GetUsuarioById(this IRepository<IAuditable> repository, int id)
            {
                return repository.FindBy(audible => audible.Id == id);
            }
        }
