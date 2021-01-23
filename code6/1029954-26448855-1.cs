     public ActionResult Create(FormCollection collection, HttpPostedFileBase image)
     {
        Student myStudent=new Student();           
        if (Request.Files.Count > 0)
            {
              string FileName = Guid.NewGuid().ToString().Replace("-", "");
              string Path = System.IO.Path.GetExtension(Request.Files[0].FileName);
              string FullPath = "~/Images/StudentPictures/" + FileName + Path;
              Request.Files[0].SaveAs(Server.MapPath(FullPath));
              myStudent.PicturePath = FileName + Path;
            }
       SqlConnection con=New SqlConnection();
       string sql=string.Format(INSERT INTO STUDENT (PICTUREPATH) VALUES('{0}') myStudent.PicturePath);
    con.SqlQuery(sql);
     }
