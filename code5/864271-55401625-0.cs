        public IActionResult PreviewDocument(int id)
        {
            Document document = _legislationFolderService.GetDocument(id);
            if (document == null)
                return NotFound($"Could not find document with id of {id}");
            return View(document);
        }
        public IActionResult PreviewDocumentContents(int id)
        {
            DocumentContents documentContents = _legislationFolderService.GetDocumentContents(id);
            if (documentContents == null)
                return NotFound($"Could not find contents for document with id of {id}");
            Response.Headers.Add("Content-Disposition", $"inline; filename={documentContents.Document.Name}.pdf");
            return new FileStreamResult(new MemoryStream(documentContents.Contents), "application/pdf");
        }
