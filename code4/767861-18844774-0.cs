        Grade grade = new Grade();    
    List<Grade> listGrade = new List<Grade>();
    listGrade = grade.getData(); // getData(); return List of all student
    List<String> nameList = new List<String>();
    List<String> gradeList = new List<String>();
    foreach(var item in listGrade)
    {
    nameList.Add(item.Name);
    gradeList.Add(item.Grade);
    }
    IEnumerable<String> resultListName = nameList.ToList();
    IEnumerable<String> resultListGrade = gradeList.ToList();
    var key = new Chart(width: 600, height: 400)
       .AddSeries(
           chartType: "bar",
           xValue: resultListName},
           yValues: resultListGrade)
           .DataBindTable(b.Students.ToList())
       .Write();
        return null;
