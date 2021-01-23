        public FileContentResult ViewResume(int id)
        {
            if (id == 0) { return null; }
            Resume resume = new Resume();
            ResumeContext rc = new ResumeContext();
            resume = rc.Resume.Where(a => a.ResumeID == id).SingleOrDefault();
            Response.AppendHeader("content-disposition", "inline; filename=file.pdf"); //this will open in a new tab.. remove if you want to open in the same tab.
            return File(resume.Resume, "application/pdf");
        }
