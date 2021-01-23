    IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForApplication();
    XDocument loadedData;
    using (IsolatedStorageFileStream isoStream = 
        new IsolatedStorageFileStream(TeachersXMLPath, FileMode.Open, storageFile))
    {
        loadedData = XDocument.Load(isoStream);
    }
    using (IsolatedStorageFileStream isoStream = 
        new IsolatedStorageFileStream(TeachersXMLPath, FileMode.Create, storageFile))
    {
        string session = tb_session.Text.ToString();
        string subject = tb_subject.Text.ToString();
        DateTime? _datetime = val_timer.Value;
        String time = _datetime.Value.Hour + ":" + _datetime.Value.Minute;
        string crdthr = ((ListPickerItem)lst_credithr.SelectedItem).Content.ToString();
        string teacher = tb_teacher.Text.ToString();
        string classroom = tb_class.Text.ToString();
        string day_week = tb_day.Text.ToString();
    
        var tchElement = new XElement("Teacher");
        var tchr = loadedData.Root.Element("Teachers");
        tchr.Add(tchElement);
        tchElement.Value = teacher;
        loadedData.Save(isoStream);
        MessageBox.Show("Added");
    }
