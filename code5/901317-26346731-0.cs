    public class YourSublayout : UserControl, IExpandable
    {
        public void Expand()
        {
            var myListOfItems = GetItems()
            foreach (var item in myListOfItems)
            {
                var placeholder = new Placeholder { Key = "key" + item.ID.ToString() };
                container.Controls.Add(placeholder); // add to a control container
                placeholder.Expand();
            }
        }
    }
