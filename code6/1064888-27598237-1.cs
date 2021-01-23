       Sql p = new Sql("Data_Set"); 
        try
        {
            p.Add("plan_table", dt); \\ A temp table 
            p.Run();
    // heare to put allert message "success"
            Response.Write("<script>alert('success');</script>");
            HttpContext.Current.Response.Redirect("/projmain/index.html"); 
    //this code are redirect page 
            return "success"; 
        }
        catch (Exception e)
        {
            return "Error saving Data <br><hr>" + e.Message + "<br><br>" + e.StackTrace + "<br><br><br><br>" + p.ToString() + "";
        }
    }
