      public Form1 ()
      {
         InitializeComponent ();
         // ....
         int [] MyTabs = {20,70,130};
         SetListTabs (lbMessages, MyTabs);
      }
      private void btnAddTabbed_Click (object sender, EventArgs e)
      {
         lbMessages.Items.Add ("1\t2\t3\t4");
         lbMessages.Items.Add ("40\t50\t60\t70");
         lbMessages.Items.Add ("100\t200\t300\t400");
      }
      private void SetListTabs (ListBox lb, IEnumerable<int> newTabs)
      {
         lb.UseCustomTabOffsets = true;
         ListBox.IntegerCollection lbTabs = lb.CustomTabOffsets;
         lbTabs.Clear ();
         foreach (int tab in newTabs)
         {
            lbTabs.Add (tab);
         }
      }
      private void btnAddTabbed_Click (object sender, EventArgs e)
      {
         lbMessages.Items.Add ("1\t2\t3\t4");
         lbMessages.Items.Add ("40\t50\t60\t70");
         lbMessages.Items.Add ("100\t200\t300\t400");
      }
