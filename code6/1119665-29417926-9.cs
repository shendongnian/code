    private void LoadStudentRecords()
    {
      // reset the list to empty, so we don't always append to existing
      _studentRecords = new List<SR>();
      string file_name = (@"C:\Users\StudentRecords.txt");
      var lines = File.ReadAllLines(file_name).ToList();
      foreach(var line in lines)
      {
        var studentRecord = ParseStudentRecordLine(line);
        if (studentRecord != null)
        {
          _studentRecords.Add(studentRecord);
        }
      }
    }
