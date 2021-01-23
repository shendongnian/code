        [Route("ControllerExample/Edit/{idVar3}/Brands")]
        public ActionResult ActionResultExample(int idVar3)
        {
            var idVar2 = 100;
            return RedirectToAction("ActionResultExample",
                new { idVar1 = idVar3, idVar2 = idVar2 });
        }
