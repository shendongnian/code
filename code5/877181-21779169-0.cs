    int myTestResult = (int)myObject.GetType().GetProperty("result").GetValue(myObject);
    string myTestName = (string)myObject.GetType().GetProperty("testName").GetValue(myObject);
    DateTime myStartTime = (DateTime)myObject.GetType().GetProperty("startTime").GetValue(myObject);
    DateTime myEndTime = (DateTime)myObject.GetType().GetProperty("endTime").GetValue(myObject);
    TimeSpan myElapsedTime = (TimeSpan)myObject.GetType().GetProperty("elapsedTime").GetValue(myObject);
    string myTestFile = (string)myObject.GetType().GetProperty("testFile").GetValue(myObject);
