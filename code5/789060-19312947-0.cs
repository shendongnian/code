    [DataObject(true)]
    public class SomeService
    {
        private Device d;
        private YourUpdaterClass yuc;
        public SomeService()
        {
            this.d = new Device();
            this.yuc = new YourUpdaterClass();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<YourType> Select()
        {
            return d.YourSelectMethod();
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(YourType yt)
        {
            yuc.YourUpdatemethod(yt);
        }
    }
