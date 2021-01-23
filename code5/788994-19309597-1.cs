     private void pd_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
       {
       single yPos = 0;
       int count = 0;
       single leftMargin = e.MarginBounds.Left;
       single topMargin = e.MarginBounds.Top;
       Image img = Image.FromFile({path to img});
       Rectangle logo = New Rectangle(40,40,50,50);
       using (Font printFont = new Font("Arial", 10.0f))
        { 
         e.Graphics.DrawImage(img, logo);
         e.Graphics.DrawString(textbox1.Text, printFont, Brushes.Black, leftMargin, yPos, New StringFormat());
        }
       //etc...
       //taken from the example and added how to draw the text from a textbox
       }
