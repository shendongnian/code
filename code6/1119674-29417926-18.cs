    public StudentRecord ParseStudentRecordLine(string line)
    {
      SR result = null;
      // error check line, don't want to blow up
      if (!string.IsNullOrWhiteSpace(line))
      {
        var values = line.Split(',');
        // error values length, don't want to blow up
        if (values.Length == 5) // or > 4
        {
          var result = new StudentRecord();
          result.lastName = values [0];
          result.firstName = values [1];
          result.middleName = values [2];
          result.date = values [3];
          result.gender = values [4];
        }
      }
      return result;
    }
