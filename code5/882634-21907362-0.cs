    public abstract class BaseEntity
    {
        public void SaveToDatabase()
        {
            var objectData = new Dictionary<string, object>();
            this.GetObjectData(objectData);
            DatabaseManager.Save(objectData);
        }
        public void LoadFromDatabase(Dictionary<string, object> data)
        {
            this.SetObjectData(data);
        }
        protected abstract void GetObjectData(Dictionary<string, object> data);
        protected abstract void SetObjectData(Dictionary<string, object> data);
    }
    public class MyEntity : BaseEntity
    {
        public int NewProperty { get; set; }
        protected override void GetObjectData(Dictionary<string, object> data)
        {
            data.Add("NewProperty", this.NewProperty);
        }
        protected override void SetObjectData(Dictionary<string, object> data)
        {
            this.NewProperty = (int)data["NewProperty"];
        }
    }
