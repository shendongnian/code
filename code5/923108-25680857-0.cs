    List<TimeTable> MyList = new List<TimeTable>(); // create the list
    foreach (XElement Teacher in loadedData.Descendants("Root").Descendants("Teachers").Descendants("Teacher"))
    {
        string teacher = Teacher.Value.ToString();
        Teacher_header.Text = teacher;
        //GetnDisplayTeachersTable(teacher);
        var data = from record in loadedData.Descendants("Root").Descendants("Schedules").Descendants("schedule")
                   where record.Attribute("teacher").Value == teacher
                   select new TimeTable
                   {
                       Teacher = (string)record.Attribute("teacher").Value,
                       Subject = (string)record.Attribute("name"),
                       Session = (string)record.Attribute("session"),
                       Group = (string)record.Attribute("group")
                   };
        MyList.Add(data);
    }
    // finally after all the read set the source
    listBox.ItemsSource = MyList;
