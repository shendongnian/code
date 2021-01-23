            [HttpPost]
            [ActionName("Edit")]
            public ActionResult UpdateDevice(DeviceModel model)
           {
            var oldcode=model.OldCode;
            var newcode=model.Code;            
            }
