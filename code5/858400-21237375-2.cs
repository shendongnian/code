    public interface IForm<T> where T: AbstractData
    {
        AbstractManager<T> GetManager();
    }
    public class BaseForm: Form
    {
        // ... base functionality that doesn't depend on T ...
    }
    public class PersonForm: BaseForm, IForm<Person>
    {
        public AbstractManager<Person> GetManager()
        {
            return new PersonManager();
        }
    }
