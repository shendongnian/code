                    while (DT1.Read())
                    {
                        //Read the record into an "array", so you can find the SProc and View names
                        int MyRptID = Convert.ToInt32(DT1[0]);
                        string MyRptName = DT1[1].ToString();
                        string MyRptSproc = DT1[2].ToString();
                        string MySQLView = DT1[3].ToString();
                        DateTime MyStDate;
                        if (string.IsNullOrWhiteSpace(this.txtStartDate.Text))
                        {
                            MyStDate = Convert.ToDateTime(this.txtStartDate.Text);
                        }
                        if (MyStDate != null)
                        {
                            cmd2.Parameters.Add("@StDate", SqlDbType.Date).Value = txtStartDate.Text;
                        }
