            Departments depart = new Departments();
            FST_Department fst = new FST_Department();
            fst.Course_Details = new List<Course>();
            Course course = new Course();
            course.Course_Code = "1";
            course.Course_Name = "Test 1";
            fst.Course_Details.Add(course);
            course = new Course();
            course.Course_Code = "2";
            course.Course_Name = "Test2";
            fst.Course_Details.Add(course);
            depart.FST_Department = fst;
            Medicine_Department med = new Medicine_Department();
            med.Course_Details = new List<Course>();
            
            course = new Course();
            course.Course_Code = "3";
            course.Course_Name = "Test 3";
            med.Course_Details.Add(course);
            depart.Medicine_Department = med;
            //put it all in some kind of order in case things were added out of order
            depart.FST_Department.Course_Details.OrderBy(c => c.Course_Code);
            depart.Medicine_Department.Course_Details.OrderBy(c => c.Course_Code);
            XMLManager.Write(depart);
