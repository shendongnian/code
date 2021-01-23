        /// <summary>
        /// Render one level of a menu. The view will call this action for each child making this render recursively.
        /// </summary>
        /// <returns></returns>
        public ActionResult Menu(int id)
        {
            var items = context.MenuItem.Find(id);
            return PartialView(items);
        }
