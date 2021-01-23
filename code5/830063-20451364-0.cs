            SqlConnection marksheetsConnection = new SqlConnection("Data Source=HIMANSHU-PC;Initial Catalog=marksheets;Integrated Security=True");
            marksheetsConnection.Open();
            SqlCommand subjectCode11 = new SqlCommand("Select SubjectCode,Subject,Type,MarksObtd,MinPassMarks,MaxMarks from Semester1", marksheetsConnection);
            SqlDataReader subjectCode11Reader = subjectCode11.ExecuteReader();
            while (subjectCode11Reader.Read())
            {
                string subjectCode1 = subjectCode11Reader.GetString(0);
                label1.Text = subjectCode1;
            }
