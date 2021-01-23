    public FileStreamResult MyAction(parameters)
    {
        var workBook = CreateWorkbook(parameters);
        var stream = new MemoryStream();
        workBook.Write(stream);
        stream.Position = 0;   
        return File(stream, "attachment;filename=myfile.xls", "myfile.xls");
    }
