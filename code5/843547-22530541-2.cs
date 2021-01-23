        public string login(string strUsername, string strPassword)
        {
            dbContext = new SchoolEntities();
            var linqQuery = from User in dbContext.People
                            where User.FirstName == strUsername && User.LastName == strPassword
                            select User;
            if (linqQuery.Count() == 1)
            {
                strMessage = "Good";
            }
            else
            {
                strMessage = "Bad";
            }
            return strMessage;
            
        }
        public Object LoadPersonDetails()
        {
            dbContext = new SchoolEntities();
            var linqQuery = from users in dbContext.People
                            select users;
            return linqQuery;
        }
        public void InsertPerson(string strLName, string strFName, string strHireDate, string EnrollmentDate)
        {
            dbContext = new SchoolEntities();
            Person NewPerson = dbContext.People.Create();
            NewPerson.LastName = strLName;
            NewPerson.FirstName = strFName;
            NewPerson.HireDate = Convert.ToDateTime(strHireDate);
            NewPerson.EnrollmentDate = Convert.ToDateTime(EnrollmentDate);
            dbContext.People.Add(NewPerson);
            dbContext.SaveChanges();
        }
        public void DeleteUser(int intPersonID)
        {
            using (dbContext = new SchoolEntities())
            {
                Person Person = dbContext.People.Where(c => c.PersonID == intPersonID).FirstOrDefault();
                if (Person != null)
                {
                    dbContext.People.Remove(Person);
                    dbContext.SaveChanges();
                }
            }
        }
        public void ModifyPerson(int intPersonID, string strLName, string strFName, string strHireDate, string EnrollmentDate)
        {
            dbContext = new SchoolEntities();
            var UpdatePerson = dbContext.People.FirstOrDefault(s => s.PersonID == intPersonID);
            UpdatePerson.LastName = strLName;
            UpdatePerson.FirstName = strFName;
            UpdatePerson.HireDate = Convert.ToDateTime(strHireDate);
            UpdatePerson.EnrollmentDate = Convert.ToDateTime(EnrollmentDate);
            dbContext.SaveChanges();
        }
        private Excel.Application XApp = null; //Creates the Excel Document
        private Excel.Workbook XWorkbook = null; //create the workbook in the recently created document
        private Excel.Worksheet XWorksheet = null; //allows us to work with current worksheet
        //private Excel.Range XWorkSheet_range = null; // allows us to modify cells on the sheet
        public void Reports()
        {
            dbContext = new SchoolEntities();
            var linqQuery = (from users in dbContext.StudentGrades
                             group users by new { users.EnrollmentID, users.CourseID, users.StudentID, users.Grade }
                             into UserGroup
                             orderby UserGroup.Key.CourseID ascending
                             select new { UserGroup.Key.EnrollmentID, UserGroup.Key.CourseID, UserGroup.Key.StudentID, UserGroup.Key.Grade }).ToList();
            var RatingAverage = dbContext.StudentGrades.Average(r => r.Grade);
            var GradeSum = dbContext.StudentGrades.Sum(r => r.Grade);
            /*var linqQuery = (from users in dbContext.StudentGrades
                             orderby users.CourseID descending
                             select users).ToList();*/
            //Array Motho = linqQuery.ToArray();
            var GradeInfo = linqQuery.ToList();
            XApp = new Excel.Application();
            XApp.Visible = true;
            XWorkbook = XApp.Workbooks.Add(1);
            XWorksheet = (Excel.Worksheet)XWorkbook.Sheets[1];
            //Create column headers
            XWorksheet.Cells[1, 2] = "Standard Student Grades Report";
            XWorksheet.Cells[2, 1] = "EnrollmentID";
            XWorksheet.Cells[2, 2] = "CourseID";
            XWorksheet.Cells[2, 3] = "StudentID";
            XWorksheet.Cells[2, 4] = "Grade";
            int row = 3;
            foreach (var Mothos in linqQuery)
            {
                XWorksheet.Cells[row, 1] = Mothos.EnrollmentID.ToString();
                XWorksheet.Cells[row, 2] = Mothos.CourseID.ToString();
                XWorksheet.Cells[row, 3] = Mothos.StudentID.ToString();
                XWorksheet.Cells[row, 4] = Mothos.Grade.ToString();
                row++;
            }
            int rows = linqQuery.Count();
            XWorksheet.Cells[rows + 4, 3] = "Grades Average";
            XWorksheet.Cells[rows + 4, 4] = RatingAverage.Value.ToString();
            XWorksheet.Cells[rows + 5, 3] = "Grades Sum";
            XWorksheet.Cells[rows + 5, 4] = GradeSum.Value.ToString();
            XWorksheet.Rows.Columns.AutoFit();
        }
        public void GroupedExcel()
        { 
            dbContext = new SchoolEntities();
            var linqQuery = from Grading in dbContext.StudentGrades
                            orderby Grading.CourseID
                            select Grading;
            var lstGrades = linqQuery.ToList();
            Excel.Application xlApp = new Excel.Application();
            xlApp.Visible = true;
            Excel.Workbook xlBook = xlApp.Workbooks.Add(1);
            Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];
            int GroupTotal = 0;
            int GrandTotal = 0;
            int ExcelRow = 5;
            int intTemp = lstGrades[0].CourseID;
            xlSheet.Cells[4, 1] = lstGrades[0].CourseID;
            //Create column headers
            xlSheet.Cells[1, 1] = "Grouped Student Grades Report";
            xlSheet.Cells[3, 1] = "Group header";
            xlSheet.Cells[3, 2] = "EnrollmentID";
            xlSheet.Cells[3, 3] = "CourseID";
            xlSheet.Cells[3, 4] = "StudentID";
            xlSheet.Cells[3, 5] = "Grade";
            for (int count = 0; count < lstGrades.Count; count++)
            {
                if (intTemp == lstGrades[count].CourseID)
                {
                    xlSheet.Cells[ExcelRow, 2] = lstGrades[count].EnrollmentID.ToString();
                    xlSheet.Cells[ExcelRow, 3] = lstGrades[count].CourseID.ToString();
                    xlSheet.Cells[ExcelRow, 4] = lstGrades[count].StudentID.ToString();
                    xlSheet.Cells[ExcelRow, 5] = lstGrades[count].Grade.ToString();
                    ExcelRow++;
                    GroupTotal++;
                    GrandTotal++;
                }
                else
                {
                    xlSheet.Cells[ExcelRow, 5] = "Total for: " + intTemp + " = " + GroupTotal.ToString();
                    ExcelRow++;
                    intTemp = lstGrades[count].CourseID;
                    xlSheet.Cells[ExcelRow, 1] = lstGrades[count].CourseID;
                    count--;
                    GroupTotal = 0;
                    ExcelRow++;
                }
            }
            xlSheet.Cells[ExcelRow, 5] = "Total for: " + intTemp + " = " + GroupTotal.ToString();
            ExcelRow++;
            xlSheet.Cells[ExcelRow, 5] = "Grand Total = " + GrandTotal.ToString();
            xlSheet.Rows.Columns.AutoFit();
        }
