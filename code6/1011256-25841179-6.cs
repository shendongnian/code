        private void ProcessDropDown(ToolStripItem item)
        {
            ToolStripMenuItem menuItem = item as ToolStripMenuItem; //Type casting from ToolStripItem to ToolStripMenuItem
            if (menuItem == null) 
                return;
            if (!menuItem.HasDropDownItems)
                return;
            else
            {
                foreach (var val in menuItem.DropDownItems)
                {
                    ToolStripMenuItem menuTool = val as ToolStripMenuItem;
                    
                    if (menuTool == null) 
                        continue;
                    
                    if (menuTool.HasDropDownItems)
                        ProcessDropDown(menuTool);
                    if (menuTool.Tag != null && menuTool.Tag.ToString() == "nagaraj")
                    {
                        menuTool.Text = false;
    				    menuItem.Visible = false;
    			    }
    		   }
    	    }
        }
