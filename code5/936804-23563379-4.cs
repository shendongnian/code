        /// <summary>
        /// Render one level of a menu, starting with the children of the specified item
        /// </summary>
        /// <returns></returns>
        public ActionResult Menu(int id)
        {
            var items = context.MenuItem.Find(id);
            return PartialView(items);
        }
