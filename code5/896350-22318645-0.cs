    System.Collections.ArrayList al = new System.Collections.ArrayList();
    int mycount = 0;
    foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
    {
        al.Insert(mycount, section.Range.Text.ToString());
        mycount++;
    }     
     mycount = 0;
     while (mycount <= al.Count)
     {
 
        MessageBox.Show(" Section Text " + al[mycount].ToString());
       mycount++;
     }
