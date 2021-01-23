    int i = 0;
    foreach (Students student in _studentList) {
       // Skapa rätt storlek för bilderna - se img control i design
       Image thumbLarge = GetThumb(student.PictureStudents, 128);
       Image thumbSmall = GetThumb(student.PictureStudents, 32);
       // Lägg till bilden i listorna med unik personnummer
       imgGalleryLarge.Images.Add(student.PersonNumberStudents, thumbLarge);
       imgGallerySmall.Images.Add(student.PersonNumberStudents, thumbSmall);
       ListViewItem lvi = new ListViewItem(student.LastnameStudents + " " +
                                           student.FirstnameStudents, i++);
       lvi.SubItems.Add(student.PhoneStudents);
       lvi.SubItems.Add(student.EmailStudents);
       lsvImageGallery.Items.Add(lvi);
    }
