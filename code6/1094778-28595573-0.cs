    var studXML = 
            new XElement("Root",
                            from student in Students 
                            select new XElement("Student",
                                        new XElement("SID",student.SID),
                                        new XElement("Name",student.Name),
                                        new XElement("Major",student.Major),
                                        from subjectGrade in student.SubjGrades
                                        select new XElement("Grade",
                                                   new XElement("Subject", subjectGrade.Subject),
                                                   new XElement("Grade", subjectGrade.grade))
                                                ) // end student
                        ); // end root
        Console.WriteLine(studXML);
