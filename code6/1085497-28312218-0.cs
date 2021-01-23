    public partial class MyView : Control
    {
        bool scrollPending;
        public MyView()
        {
            InitializeComponent();
            myDataGrid.IsVisibleChanged += myDataGrid_IsVisibleChanged;
            myDataGrid.DataContextChanged += myDataGrid_DataContextChanged;
        }
        void myDataGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
			if (/* The list is not empty */)
			{
				if (!myDataGrid.IsVisible)
				{
					scrollPending = true;
				}
				else
				{
					myDataGrid.ScrollIntoView(/* The last item in the list */);
					scrollPending = false;
				}
			}
			else
			{
				scrollPending = false;
			}
        }
        void myDataGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (scrollPending && myDataGrid.IsVisible /* && list is not empty */ )
            {
                myDataGrid.ScrollIntoView(/* The last item in the list */);
                scrollPending = false;
            }
        }
	}
