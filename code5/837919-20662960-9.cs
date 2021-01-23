    public partial class DynamicForm : Form, IDynamicView
    {
        public void AddItemToControlList(SomeItem item)
        {
            this.ControlList.Add(item);
        }
    }
