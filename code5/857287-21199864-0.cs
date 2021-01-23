        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
          if (e.Node == null) return;
          
          var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
          var unfocused = !e.Node.TreeView.Focused;
          
          // we need to do owner drawing only on a selected node
          // and when the treeview is unfocused, else let the OS do it for us
          if (selected && unfocused)
          {
            var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
          }
          else
          {
            e.DrawDefault = true;
          }
        }
