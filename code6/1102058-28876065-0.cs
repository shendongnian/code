    response.Clear();
    response.AppendHeader("Content-Disposition", "inline;filename=" + "abc.pdf");
    response.BufferOutput = true;
    response.ContentType = System.Net.Mime.MediaTypeNames.Application.Pdf;
    response.BinaryWrite(contents);
    response.End();
