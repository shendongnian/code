    public class ArchitectRepository : IArchitectRepository
    {
        // implement all the IArchitectRepository methods
    
        public void Dispose()
        {
            // assuming your repository has a connection property
            if (this.Connection != null)
                this.Connection.Close();
            // do the same for all other disposable objects your repository has created.
        }
    }
