        /// <summary>
        /// Reorder the passed element , so that it appears after the specific element
        /// </summary>
        /// <param name="id">Id of element to move</param>
        /// <param name="after">Id of element to place after (or 0 to place first)</param>
        /// <returns>Unused</returns>
        public ContentResult Reorder( int id, int after )
        {
            var movedItem = this.context.MenuItem.Find(id);
            
            // Find all the records that have the same parent as our moved item
            var items = this.context.MenuItem.Where(x => x.ParentMenuItemId == movedItem.ParentMenuItemId).OrderBy(x => x.DisplayOrder);
            // Where to insert the moved item
            int insertionIndex = 1;
            
            // Display order starts at 1
            int displayOrder = 1;
            // Iterate all the records in sequence, skip the insertion value and update the display order
            foreach (var item in items)
            {
                // Skip the one to move as we will find it's position
                if (item.MenuItemId != id)
                {
                    // Update the position
                    item.DisplayOrder = displayOrder;
                    if (item.MenuItemId == after)
                    {
                        // Skip the insertion point for subsequent entries
                        displayOrder++;
                        // This is where we will insert the moved item
                        insertionIndex = displayOrder;
                    }
                    displayOrder++;
                }
            }
            // Now update the moved item
            movedItem.DisplayOrder = insertionIndex;
            this.context.SaveChanges();
            return Content(insertionIndex.ToString());
        }
