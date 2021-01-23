        public ActionResult Edit(string Id)
        {
            return RedirectToAction("NotYetImplemented", "SystemManagement");
        }
        /// <summary>
        ///     To work around the base class requiredment that the Id be a long we override the
        ///     base class and mark this as not an action. Use the string version instead.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [NonAction]
        public override ActionResult Edit(long Id)
        {
            return RedirectToAction("NotYetImplemented", "SystemManagement");
        }
