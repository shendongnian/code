    public class MyRepo<T> : IRepo<T> {
        private readonly IConnectionFactory connectionFactory;
        public MyRepo(IConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;
        }
    }
