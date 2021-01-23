      /// <summary>
      /// Returns copies of all menu shortcut items in the main form.
      /// </summary>
      /// <returns>A list containing copies of all of the menu items with a keyboard shortcut.</returns>
      public static List<ToolStripMenuItem> GetMenuShortcutClones()
      {
         List<ToolStripMenuItem> shortcutItems = new List<ToolStripMenuItem>();
         Stack<ToolStripMenuItem> itemsToBeParsed = new Stack<ToolStripMenuItem>();
         foreach (ToolStripItem menuItem in mainForm.menuStrip.Items)
         {
            if (menuItem is ToolStripMenuItem)
            {
               itemsToBeParsed.Push((ToolStripMenuItem)menuItem);
            }
         }
         while (itemsToBeParsed.Count > 0)
         {
            ToolStripMenuItem menuItem = itemsToBeParsed.Pop();
            
            foreach (ToolStripItem childItem in menuItem.DropDownItems)
            {
               if (childItem is ToolStripMenuItem)
               {
                  itemsToBeParsed.Push((ToolStripMenuItem)childItem);
               }
            }
            if (menuItem.ShortcutKeys != Keys.None)
            {
               shortcutItems.Add(CloneMenuItem(menuItem));
            }
         }
         return shortcutItems;
      }
      /// <summary>
      /// Returns an effective shortcut clone of a ToolStripMenuItem. It does not copy the name
      /// or text, but it does copy the shortcut and the events associated with the menu item.
      /// </summary>
      /// <param name="menuItem">The MenuItem to be cloned</param>
      /// <returns>The newly generated clone.</returns>
      private static ToolStripMenuItem CloneMenuItem(ToolStripMenuItem menuItem)
      {
         ToolStripMenuItem copy = new ToolStripMenuItem();
         copy.ShortcutKeys = menuItem.ShortcutKeys;
         copy.Tag = menuItem.Tag;
         var eventsField = typeof(Component).GetField("events", BindingFlags.NonPublic | BindingFlags.Instance);
         var eventHandlerList = eventsField.GetValue(menuItem);
         eventsField.SetValue(copy, eventHandlerList);
         return copy;
      }
