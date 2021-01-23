    List<PictureBox> pboxes = new List<PictureBox>();
    foreach(var ctl in panel1.Controls)
    {
       var box = ctl as PictureBox;
    
       if(box != null)
       {
           pboxes.Add(box);
       }
    }
    // pboxes now contains all PB. You can call "AsArray()" LINQ method on it to get an array rather than a List.
