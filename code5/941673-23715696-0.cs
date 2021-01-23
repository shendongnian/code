            XDocument doc = XDocument.Load("YourXmlFileNameHere.xml");
            List<XElement> CoursesInDepartment1;
    
            // Step 1
            CoursesInDepartment1 = doc.Element("Departments").Element("Department1").Elements().ToList();
    
            // Step 2
            foreach (XElement elem in CoursesInDepartment1) {
                TextBox nameBox = new TextBox();
                TextBox codeBox = new TextBox();
                //Set the location, size, ect.
    
                //Step 3
                nameBox.Text = elem.Element("CourseName").Value;
                codeBox.Text = elem.Element("CourseCode").Value;
    
                this.Controls.Add(nameBox.Text);
                this.Controls.Add(codeBox.Text);
            }
    
            Console.ReadLine();
