    public class FakeRepositoryFactory {
      T Repository<T>() {
        ..... // find class that implements T in Assemblies of fake repositories
        return repository;
      }
    };
    public class FakeUserRepository : public IUserRepository {
        User FindByEmail(string email) {
          // create mocked user for testing purposes ....
          return userMock;
        }
    };
