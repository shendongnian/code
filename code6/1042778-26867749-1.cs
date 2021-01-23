     [AjaxOnly]
        public JsonResult VerificarEliminarLibro(string bookId)
        {
            bookModel ModeloLibro = new bookModel();
            bool HayLibrosPrestados = ModeloLibro.VerificarLibroPrestado(bookId);
            if (HayLibrosPrestados == true)
            {
                return Json(new { esteLibroEstaPrestado = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { esteLibroEstaPrestado = false }, JsonRequestBehavior.AllowGet);
            }
        }
