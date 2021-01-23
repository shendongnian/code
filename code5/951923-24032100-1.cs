    public class MockRepo : IRepository
    {
        public int method(int input)
        {
            throw new RepositoryException();
        }
    }
