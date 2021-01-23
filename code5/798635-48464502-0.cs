    /// <summary>
    /// A static helper class providing extension methods to SelectList instances
    /// </summary>
    public static class SelectListExtensions
    {
        /// <summary>
        /// Adds the specified value to the select list.
        /// </summary>
        /// <param name="selectList">The select list.</param>
        /// <param name="value">The value.</param>
        /// <param name="text">The text.</param>
        /// <param name="selected">if set to <c>true</c> [selected].</param>
        /// <returns>The modified/rebuilt select list</returns>
        public static SelectList Add(this SelectList selectList, string value, string text, bool selected = false)
        {
            var itemList = selectList.ToList().FluentAdd(
                new SelectListItem { Value = value, Text = text, Selected = selected }
            );
            return new SelectList(itemList, "Value", "Text");
        }
        /// <summary>
        /// Prepends the specified value to the select list.
        /// </summary>
        /// <param name="selectList">The select list.</param>
        /// <param name="value">The value.</param>
        /// <param name="text">The text.</param>
        /// <param name="selected">if set to <c>true</c> [selected].</param>
        /// <returns>The modified/rebuilt select list</returns>
        public static SelectList Prepend(this SelectList selectList, string value, string text, bool selected = false)
        {
            var itemList = selectList.ToList();
            itemList.Insert(0, new SelectListItem { Value = value, Text = text, Selected = selected });
            return new SelectList(itemList, "Value", "Text", selectList.SelectedValue);
        }
    }
