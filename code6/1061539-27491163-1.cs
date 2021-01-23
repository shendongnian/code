    public static class Extensions {
        public IEnumerable<IAuditable> GetUsuarioId(this IRepository<IAuditable> repository, int usuarioId) {
            return repository.FindBy(a => a.UsuarioId == usuarioId);
        }
    }
