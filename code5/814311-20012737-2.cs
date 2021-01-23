    public class GridViewColumnFileName : GridViewColumn
    {
        public GridViewColumnFileName()
        {
            DisplayMemberBinding = new Binding("Key")
            {
                Mode = BindingMode.OneWay
            };
        }
    }
