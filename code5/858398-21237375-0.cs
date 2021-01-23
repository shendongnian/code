    public class BaseForm<T> : Form
        where T : AbstractData
    {
        public virtual AbstractManager<T> GetManager()
        {
            return null;
        }
    }
    public class PersonForm : BaseForm<Person>
    {
        public override AbstractManager<Person> GetManager()
        {
            return new PersonManager();
        }
    }
