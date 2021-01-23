            return new StreamResponse(() =>
            {
                var pdfOutput = new MemoryStream(bytes); 
                pdfOutput.Seek(0, SeekOrigin.Begin);
                return pdfOutput;
            }, "application/pdf").WithHeader("Content-Disposition", "attachment; filename=" + attachmentName);
