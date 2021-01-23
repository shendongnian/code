     ............................................
     ................................................
            DataTable dt1 = new DataTable();
            dapt1.Fill(dt1);
       DataTable dtMain=new DataTable();
     foreach (DataRow row in dt1.Rows)
        {
            string twsIDName = row.ItemArray[1].ToString();
            string startTime = GetStartTime(row.ItemArray[0].ToString(), int.Parse(twsIDName));
            string endTime = GetEndTime(row.ItemArray[0].ToString(), int.Parse(twsIDName));
            DateTime dat1 = DateTime.Parse(startTime);
            DateTime dat2 = DateTime.Parse(endTime);
            string endingTime;
            if (endTime == string.Empty || endTime == null || dat2 < dat1)
            {
                endingTime = "";
            }
            else
            {
                endingTime = endTime.Remove(0, 3).ToString();
            }
            string startingTime = startTime.Remove(0, 3).ToString();
            String strQu2;
            strQu2 = "SELECT JOBNAME, TWSID, HIGHPRIORITY, DAY, TIME, '"+ startingTime + "' as StartTime, '"+ endingTime + "' as EndTime FROM JOB_DETAILS_TEST WHERE TWSID = " + int.Parse(twsIDName) + " AND REGIONID = " + regionID + " ORDER BY JOBNAME";
            OleDbDataAdapter dapt2 = new OleDbDataAdapter(strQu2, con);
            DataTable dtTemp=new 
            dapt2.Fill(dtTemp);
            
           if(dtTemp.Rows.Count>0)
           {
              dtMain.Merge(dtTemp);
           }
        }
            dgJobStatusAll.AutoGenerateColumns = true;
            dgJobStatusAll.DataSource = dtTemp;
            //dgJobStatusAll.DataMember = "dt2";
    }
