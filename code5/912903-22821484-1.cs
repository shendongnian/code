       List<string> listAttendance = new List<string>();
        foreach (DataGridViewRow row in dgv_attendence.Rows)
        {
            if (row.Cells[0].Value != null && (Boolean)row.Cells[0].Value == true )
            {
               attendance = "Present";
            }
            else
            {
                attendance = "Absent";
            }
            listAttendance.Add( attendance);
         }
