    public int CheckMatch(CourseSchedule courseInfo)
    {
         string get_number = 
              "SELECT count(c_t_id) " +
              " FROM course_teacher_table" +
              " WHERE room_number = @Room AND class_days = @Days AND class_time = @Time";
        //.Net works best when you create a brand new connection object for most queries
        using (var cn As New SqlConnection("connection string here"))
        using (var cmd As New SqlCommand(get_number, cn))
        {
            //I'm guessing at sql column types here. Use the actual column types from the DB.
            cmd.Parameters.Add("@Room", SqlDbType.NVarChar, 5).Value = courseInfo.RoomNumber;
            cmd.Parameters.Add("@Days", SqlDbType.Int).Value = courseInfo.Days;
            cmd.Parameters.Add("@Time", SqlDbType.NVarChar, 20).Value = courseInfo.ClassTime;
            cn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()); 
        }
    }
