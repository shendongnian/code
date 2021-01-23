    public class BaseClass
    {
        protected string name;
        private void NameChanged()
        {
             ...
        }
        public void SetName(string value)
        {
            this.name = value;
            this.NameChanged();
        }
    }
