    public class MainModel
    {
        public ItemViewModel Collection1 { get; set; }
        public void LoadData()
        {
            Collection1=CreateCollection();
