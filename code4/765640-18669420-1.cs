    IssueDate = Date()
    ? IssueDate
    9/6/2013 
    ? Year(IssueDate)
     2013 
    ? Month(IssueDate)
     9 
    ' now get the date for first of this month ...
    ? DateSerial(Year(IssueDate), Month(IssueDate), 1)
    9/1/2013 
    ' now get the date for the last of this month ...
    ? DateSerial(Year(IssueDate), Month(IssueDate) + 1, 0)
    9/30/2013 
