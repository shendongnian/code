        protected void SomeEventHandler(object sender, EventArgs e)
        {
            // Create list of strings to hold ID values
            List<string> locIDs = new List<string>();
            // Build list of actual string values
            foreach (var item in SomeControl.Items)
            {
                locIDs.Add(value);
            }
            // Build SELECT command
            SqlDataSource1.SelectCommand = String.Format("Select ID, RoomNum from [dbo].[Mbiology] WHERE LocId IN ({0})", 
                String.Join(", ", productIDs.ToArray()));
        }
 
