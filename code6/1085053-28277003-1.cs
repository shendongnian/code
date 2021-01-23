    public class myTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            container.DataBinding +=container_DataBinding;
        }
        private void container_DataBinding(object sender, EventArgs e)
        {
            //get current data item associated with the row where the template is
            var data = DataBinder.GetDataItem(((Control)sender).NamingContainer);
            //I'm supposing I bound an object collection with a property Name, but this is generic like you do with Eval in aspx.
            var fieldValue = DataBinder.Eval(data, "Name");
            //here you can use the field value to add controls to the container, just cast the sender to a Control type
        }
    }
