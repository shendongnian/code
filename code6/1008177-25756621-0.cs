    public JsonResult ExisteCodOp(string Codigo_Operador)
        {
            ModeloDePool1 ModeloPool1 = new ModeloDePool1();
            bool ExisteCodOp = ModeloPool1.CheckCodOp(Codigo_Operador);
            if (ExisteCodOp == false)
            {
                return Json("No existe el KVD escrito.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
