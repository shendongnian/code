    public JsonResult MyAction(string[] lines)
    {
        Console.WriteLine(lines); // Display nothing
        return Json(new { data = 0 });
    }
