    public class childForm : Form
    {
        private IEnumerable<SomeClass> itemsFromParent;
        public childForm(IEnumerable<SomeClass> itemsFromParent)
        {
            ...
            ...
            this.itemsFromParent = itemsFromParent;
        }
    }
