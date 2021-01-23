    public ActionResult Serializing(Models.SerializerModel model)
    {
        var username = model.Username.ToString();
        if (ModelState.IsValid)
        {
            string path = Server.MapPath("~/xml");
            //First write to file. using statement will take care of closing writer stream. 
            XmlSerializer serial = new XmlSerializer(model.GetType());
            using (var writer = new System.IO.StreamWriter(path + "\\" + username + ".xml"))
            {
                serial.Serialize(writer, model);
                writer.Flush();
            }
            
            //This code below i want to execute after the above one is done
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/xml";
            //During WriteFile i get the error IO
            Response.WriteFile(Server.MapPath("~/xml/hello.xml"));
            Response.Flush();
            //Response.End();   I am not sure if this statement is really needed here.
            return RedirectToAction("Index", "Profile");
        }
        return RedirectToAction("Index", "Profile");
    }
