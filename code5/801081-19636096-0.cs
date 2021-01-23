    public class ExampleViewModel
    {
        public string Image {get; set;}
        public string Text {get; set;}
    }
    public ActionResult Controller(ExampleViewModel model)
    {
        //Not sure how you wanted to get the image so I just put this in here
        foreach (string file in Request.Files)
        {
            HttpPostedFileBase hpf=Request.Files[file] as HttpPostedFileBase;
            if(hpf.ContentLengh==0)
            continue;
            string folderPath = Server.MapPath("~/yourFolderPath");
            Directory.CreateDirectory(folderPath);
            string savedFileName = Server.MapPath("~/yourFolderPath/" + hpf.FileName);
            hpf.SaveAs(savedFileName);
            model.Image="~/yourFolderPath/" + hpf.FileName;
        }
        //this variable is getting the text from the ViewModel
        string text=model.Text;
    }
