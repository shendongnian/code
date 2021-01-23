    partial class EmailSenderGUI
    {
        //My method that I made
        private void initRecipListView()
        {
            System.Console.WriteLine("Test");
            this.recipList.Columns.Add("Recipient", -2, System.Windows.Forms.HorizontalAlignment.Left);
            this.recipList.Columns.Add("Number of Reports", -2, System.Windows.Forms.HorizontalAlignment.Left);
        }
    }
