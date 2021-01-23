    string subject = "Hello (1)";
    string newSubject = string.Empty;
    
    for (int j = 0; j < subject.Length; j++)
        if (char.IsNumber(subject[j]))
             newSubject += subject[j];
    
    int number = 0;
    
     int.TryParse(newSubject, out number);
     subject = subject.Replace(number.ToString(), (++number).ToString());
