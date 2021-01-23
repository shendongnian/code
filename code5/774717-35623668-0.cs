        string consString = ConfigurationManager.ConnectionStrings["SheetalAcademy"].ConnectionString;
        SqlConnection conn = new SqlConnection(consString);
       
        int EID = Convert.ToInt32(Session["EmailID"].ToString());
        SqlCommand cmd = new SqlCommand("Select id,Course_Name from tbl_Courses where EID='" + EID + "' and Active='True'", conn);
        conn.Open();
        ddCourseType.Items.Clear();
        ddCourseType.Items.Add("All");
        ddCourseType.AppendDataBoundItems = true;
        ddCourseType.DataSource = cmd.ExecuteReader();
        ddCourseType.DataTextField = "Course_Name";
        ddCourseType.DataValueField = "id";
        ddCourseType.DataBind();
        conn.Close();
    }
