            DateTime dateofclaim = new DateTime(); // define dateofclame to a new date  
        
            for (int i = 0; i < months; i++) // for each month run the code below, this will first run the fromDate then add a month until it gets to the toDate
            {
                dateofclaim = fromDate.AddMonths(i); // add one month to the start date
                claimfromDate = (dateofclaim.AddDays(1 - dateofclaim.Day)); // calculate the first date of the month
                claimtoDate = (dateofclaim.AddDays(1 - dateofclaim.Day)).AddMonths(1).AddDays(-1); // calculate the last day of the month
                OleDbCommand com = new OleDbCommand("SELECT sum([sum]) FROM Attendance WHERE ([Attendance_Date]) >= ? AND ([Attendance_Date]) <= ? AND [Person] = ?", Program.DB_CONNECTION); // count the total attendances in the month
                com.Parameters.Add(new OleDbParameter("", claimfromDate));
                com.Parameters.Add(new OleDbParameter("", claimtoDate));
                com.Parameters.Add(new OleDbParameter("", person.ID));
                OleDbDataReader dr = com.ExecuteReader(); // start reader  
                if (dr.Read()) // if a result is returned
                {
                    try
                    {
                        int attendance = Convert.ToInt32(dr.GetDouble(0)); // this is how many attendances have been counted for the selected month
                        ws.get_Range("B" + row.ToString()).Value2 = dateofclaim.ToString("MMM yyyy"); // print the Month of the clame into Colum B and row 83 then adding one for each following month
                        ws.get_Range("I" + row.ToString()).Value2 = attendance.ToString(); // print the number of attendances into Colum B and the respective row
                        row++; // add one to the row so next time this runs the data will be on the next row 
                    }
                    catch // if nothing as returned from the database then add the month and 0 in the attendance colum
                    {
                        ws.get_Range("B" + row.ToString()).Value2 = dateofclaim.ToString("MMM yyyy");
                        ws.get_Range("I" + row.ToString()).Value2 = "0";
                        row++;
                    }
                }
                dr.Close(); // close the database reader
            }
