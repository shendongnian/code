    var xdoc = XDocument.Load("students.xml");
    var students = xdoc.Root.Elements("student")
                       .Select(st => new Student {
                           Id = (int)st.Element("id"),
                           Subjects = st.Element("data")
                                        .Elements("subject")
                                        .Select(s => new Subject {
                                            Name = (string)s.Attribute("name"),
                                            Status = (string)s.Attribute("status")
                                         }).ToList()
                        }).ToList();
