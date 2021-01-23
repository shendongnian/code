    protected void view_Report(object sender, EventArgs e)
            {
		//=====Change Code===========================
	        ViewState["PrevRecordStudentID"] = 0;
                ViewState["PrevRecordFirstName"] = "";
                ViewState["PrevRecordLastName"] = "";
		//=====Change Code===========================
                String classname = txt_classname.SelectedValue;
                db = new DBConnection();
                db.getConnection();
                dt = db.executeSelectQuery("select s.StudentID,s.FirstName,s.LastName,eh.ExamID,eh.ExamName,sub.SubjectName,se.Marks,se.Result from ExamHeader eh inner join Grade g on eh.GradeName = g.GradeName inner join Class c on c.GradeName = g.GradeName inner join StudentToExam se on se.ExamID = eh.ExamID inner join Student s on s.StudentID = se.StudentID inner join Subject sub on eh.ExamSubjectID = sub.SubjectID where c.ClassName = '"+classname+"' and eh.ExamPublished = 'Yes' and eh.ExamDate <= GETDATE() order by s.StudentID");
                tbl_report.DataSource = dt;
                tbl_report.DataBind();
            }
    //=====Add Code===========================
     protected void tbl_report_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == Convert.ToString(ViewState["PrevRecordStudentID"]) && e.Row.Cells[1].Text == Convert.ToString(ViewState["PrevRecordFirstName"]) && e.Row.Cells[2].Text == Convert.ToString(ViewState["PrevRecordLastName"]))
                {
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[1].Text = "";
                    e.Row.Cells[2].Text = "";
                }
                else
                {
                    ViewState["PrevRecordStudentID"] = Convert.ToInt32(e.Row.Cells[0].Text) ;
                    ViewState["PrevRecordFirstName"] = Convert.ToString(e.Row.Cells[1].Text);
                    ViewState["PrevRecordLastName"] = Convert.ToString(e.Row.Cells[2].Text);
                }
            }
        }
    //=====Add Code===========================
    //=====Change Code===========================
     <asp:GridView ID="tbl_report" runat="server" AutoGenerateColumns="False" 
            GridLines="None" CssClass="CSSTable" onrowdatabound="tbl_report_RowDataBound">
    //=====Change Code===========================
