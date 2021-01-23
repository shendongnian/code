    [XmlRoot("ps")]
    public class ItemCollection : List<object>
    {
        private static List<object> _items;
        private List<object> Items
        {
            get
            {
                if(_items == null)
                {
                    _items= new List<object>();
                }
                return _orders;
            }
        }
    }
