    private void Form1DragDrop(object sender, DragEventArgs e)
    {
       Startup();
       Microsoft.Office.Interop.Outlook.ApplicationClass oApp = 
             new Microsoft.Office.Interop.Outlook.ApplicationClass();
       Microsoft.Office.Interop.Outlook.Explorer oExplorer = _Outlook.ActiveExplorer();
       Microsoft.Office.Interop.Outlook.Selection oSelection = Explorer.Selection;
       foreach (object item in oSelection)          
       {
           Microsoft.Office.Interop.Outlook.MailItem mi = 
            (Microsoft.Office.Interop.Outlook.MailItem)item;
          //    rTB_test.Text = mi.Body.ToString();
          Label lbl = new Label();
          lbl.AutoSize = false;
          lbl.Size = new Size( 80, 50);         // <-- your choice!
          lbl.Text = someText;                 // <-- your choice!
          lbl.TextAlign = ContentAlignment.BottomCenter;
          lbl.Image = someImage;             // <-- your choice!
          lbl.ImageAlign = ContentAlignment.TopCenter;
          int count = rTB_test.Controls.Count;
          int itemsPerRow = rTB_test.Width / 80;
          lbl.Location = new Point( (count % itemsPerRow) * 80, 
                                     count / itemsPerRow * 50); 
          lbl.Tag = mi;
          lbl.MouseDoubleClick += lbl_MouseDoubleClick;
          lbl.Parent = rTB_test;
       }
    }
 
    void lbl_MouseDoubleClick(object sender, MouseEventArgs e)
    {
       Microsoft.Office.Interop.Outlook.MailItem mi = 
         (Microsoft.Office.Interop.Outlook.MailItem) ( (Label)sender).Tag;
       // code to process the doubleclicked mail item..
    }
