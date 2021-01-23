    public abstract class BaseBusinessObject<TEntity, TIdentifier> : Repository<TEntity, TIdentifier>
    {
        ... base stuff here
    }
    public class AuthorizationBusinessObject : BaseBusinessObject<Authorization, int>
    {
    }
