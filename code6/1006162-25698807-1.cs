    public ActionResult Pic()
    {
        System.IO.File.AppendAllText("D:\\test.txt", "test" + Environment.NewLine);
        return File("D:\\Untitled.png", "image/png", "Untitled.png");
                                                         ^^^
                                                    // Add this
    }
