    namespace SortImagesInDGV
    {
        public partial class Form1 : Form
        {
            SortableBindingList<CustomObject> mySortableBindingList;
            Image C32 = SortImagesInDGV.Properties.Resources.C_32.ToBitmap();
            Image X32 = SortImagesInDGV.Properties.Resources.X_32.ToBitmap();
            Image Q32 = SortImagesInDGV.Properties.Resources.Q_32.ToBitmap();
            // used to keep track of sort direction
            bool SortingFlipFlop = true;
            public Form1()
            {
                InitializeComponent();
                mySortableBindingList = new SortableBindingList<CustomObject>();
                mySortableBindingList.Add(new CustomObject("c mark", 1, C32));
                mySortableBindingList.Add(new CustomObject("x mark", 3, X32));
                mySortableBindingList.Add(new CustomObject("q mark", 2, Q32));
                mySortableBindingList.Add(new CustomObject("cross mark", 3, X32));
                mySortableBindingList.Add(new CustomObject("check mark", 1, C32));
                mySortableBindingList.Add(new CustomObject("question mark", 2, Q32));
                dataGridView1.DataSource = mySortableBindingList;
                // Sorting image with this event
	            dataGridView1.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(gridViewData_ColumnHeaderMouseClick);           
                // Must explicitly set the image column as sortable
                dataGridView1.Columns["AnImage"].SortMode = DataGridViewColumnSortMode.Automatic;
                // Hide the number "key" column
                dataGridView1.Columns["ANumber"].Visible = false;
            }
   
                void gridViewData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	            {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "AnImage")
                    {
                        // Change the sort direction each time the column header for image is clicked
                        ListSortDirection Direction;
                        if (SortingFlipFlop) { Direction = ListSortDirection.Ascending; SortingFlipFlop = false; }
                        else { Direction = ListSortDirection.Descending; SortingFlipFlop = true; }
                        // Perform the sort on the number / 'key' column
                        dataGridView1.Sort(dataGridView1.Columns["ANumber"], Direction);
                        // Show the sorting glyph in the image column
                        if (Direction == ListSortDirection.Ascending)
                        { dataGridView1.Columns["AnImage"].HeaderCell.SortGlyphDirection = SortOrder.Descending; }
                        else if (Direction == ListSortDirection.Descending)
                        { dataGridView1.Columns["AnImage"].HeaderCell.SortGlyphDirection = SortOrder.Ascending; }
                        else { dataGridView1.Columns["AnImage"].HeaderCell.SortGlyphDirection = SortOrder.None; }
                    }
	            }
        }
