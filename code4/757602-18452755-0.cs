    public class RepositoryFactory {
        public static DatabaseInterface MakeDAL() {
            return new DatabaseAccess();
        }
    }
