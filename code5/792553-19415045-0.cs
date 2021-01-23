    class Program
    {
        static void Main(string[] args) {
        var repo = new RepositorioPacientes();
        var editando = repo.SingleOrDefault(p => p.Id == 1);
        editando.Nome = "Novo Helton Moraes";
        repo.Update(editando);
      }
    }
