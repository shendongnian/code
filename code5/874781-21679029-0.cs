    protected void Page_Load(object sender, EventArgs e)
        {
            //string DOB;
            if (Session["UserAuthentication"] != null)
            {
                Student student = (Student)Session["UserAuthentication"];
                lbStudentNum.Text= student.StudentNumber ;
                City.Text= student.City;
                Postcode.Text= student.Postcode ; 
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
