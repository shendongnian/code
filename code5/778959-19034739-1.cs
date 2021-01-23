    public ActionResult GetFile(Int32 CategoryId)
    {
      if (/*can be written*/)
      {
        using (MemoryStream stream = new MemoryStream())
        {
          using (StreamWriter writer new StreamWriter(stream))
          {
            /* writer.Write(...); */
          }
          return File(stream, "text/plain");
        }
      }
      return Redirect("~/main/Page"); // or redirectToRoute/RedirectToAction
    }
