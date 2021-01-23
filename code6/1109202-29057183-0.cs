    DataTable Lessons;
        int lessonIndex = 0;
        private void combo_DropDown(object sender, EventArgs e)
        {
            SqlConnection conDateBase = new SqlConnection();
            conDateBase.ConnectionString = connectionString;
            conDateBase.Open();
            string query = "SELECT [Lesson ID],[LessonName],[LessonCredits] from Lessons WHERE ClassID = @CLASS_ID";
            SqlCommand cmdDatabase = new SqlCommand(query, conDateBase);
            cmdDatabase.Parameters.Add("@CLASS_ID", System.Data.SqlDbType.VarChar).Value = txtClassID.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmdDatabase);
            DataSet dSet = new System.Data.DataSet();
            adapter.Fill(dSet, "Lessons");
            Lessons = dSet.Tables["Lessons"];
            lessonIndex = 0;
            refreshValues();
        }
        private void btnPreviousLesson_Click(object sender, EventArgs e)
        {
            if (lessonIndex > 0 && Lessons != null && Lessons.Rows.Count > 0)
            {
                lessonIndex--;
                refreshValues();
            }
        }
        private void btnNextLesson_Click(object sender, EventArgs e)
        {
            if (Lessons != null && Lessons.Rows.Count > 0 && lessonIndex < Lessons.Rows.Count - 1)
            {
                lessonIndex++;
                refreshValues();
            }
        }
        private void refreshValues()
        {
            txtLessID1.Text = Lessons.Rows[lessonIndex]["Lesson ID"].ToString();
            txtLessName1.Text = Lessons.Rows[lessonIndex]["LessonName"].ToString();
            txtLessCred1.Text = Lessons.Rows[lessonIndex]["LessonCredits"].ToString();
        }
