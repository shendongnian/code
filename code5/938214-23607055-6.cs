    public abstract class Entity
    {
        public virtual void OnSave();
    }
    public class Transaction : Entity
    {
        public string ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public override void OnSave()
        {
            ID = Guid.NewGuid().ToString(); //call to class library
        }
    }
