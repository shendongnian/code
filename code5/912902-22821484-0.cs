       List<string> listAttendance = new List<string>();
        foreach (DataGridViewRow row in dgv_attendence.Rows)
        {
            if (row.Cells[0].Value != null)
            {
                if ((Boolean)row.Cells[0].Value == true)
                {
                    attendance = "Present";
                }
                else if ((Boolean)row.Cells[0].Value == false)
                {
                    attendance = "Absent";
                }
                listAttendance.Add( attendance);
            }
        }
