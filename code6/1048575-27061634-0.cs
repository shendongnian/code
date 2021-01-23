    public ActionResult Image(int PersonID)
            {
                System.Drawing.Image image = ClientFunctions.GetStudentImage(GlobalVariables.networkstuff, GlobalVariables.testAuth, PersonID);
    
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Jpeg);
    
                    return File(ms.ToArray(), "image/jpeg");
                }
            }
