    List<float> grades = new List<float>();
    
    float grade;
    
    if (!string.IsNullOrWhiteSpace(txtGrade1.Text) && float.TryParse(txtGrade1.Text, out grade))
        grades.Add(grade);
    
    if (!string.IsNullOrWhiteSpace(txtGrade2.Text) && float.TryParse(txtGrade2.Text, out grade))
        grades.Add(grade);
    
    if (!string.IsNullOrWhiteSpace(txtGrade3.Text) && float.TryParse(txtGrade3.Text, out grade))
        grades.Add(grade);
    ...
    if (grades.Count > 0 && credits.Count > 0)
         averageGrade = grades.Sum() / credits.Sum();
     
