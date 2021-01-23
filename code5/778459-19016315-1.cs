        //populate the data table dt
        //...
        //bind
        calendarGridView.DataSource = dt;
        //add a new link column (with some properties...) to the gridview
        DataGridViewLinkColumn copyIDLinkColumn = new DataGridViewLinkColumn();
       
        copyIDLinkColumn.UseColumnTextForLinkValue = true;
        copyIDLinkColumn.HeaderText = "Copy";
        copyIDLinkColumn.ActiveLinkColor = Color.White;
        copyIDLinkColumn.LinkBehavior = LinkBehavior.SystemDefault;
        copyIDLinkColumn.LinkColor = Color.Blue;
        copyIDLinkColumn.TrackVisitedState = true;
        copyIDLinkColumn.VisitedLinkColor = Color.Red;
        calendarGridView.Columns.Add(copyIDLinkColumn);
        copyIDLinkColumn.Text = "Click Me"; //Set it once as a default for all cells in col.
                         
        //...
        // Event to handle column click (needs to be wired from designer for example)
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        //copy some data to clipboard...
        System.Windows.Forms.Clipboard.SetText(e.RowIndex.ToString());
        MessageBox.Show(e.RowIndex.ToString());
        }
