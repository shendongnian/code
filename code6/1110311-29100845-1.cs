    namespace CountLinesExtension
    {
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".txt")]
    public class Class1 : SharpContextMenu
    {
    protected override bool CanShowMenu()
    {
            //  We will always show the menu.
            return true;
            //throw new NotImplementedException();
        }
        protected override ContextMenuStrip CreateMenu()
        {
            //  Create the menu strip.
            var menu = new ContextMenuStrip();
            //  Create a 'count lines' item.
            var itemCountLines = new ToolStripMenuItem
            {
                Text = "Count Lines"
            };
            //  When we click, we'll call the 'CountLines' function.
            itemCountLines.Click += (sender, args) => CountLines();
            //  Add the item to the context menu.
            menu.Items.Add(itemCountLines);
            //  Return the menu.
            return menu;
            //throw new NotImplementedException();
        }
        private void CountLines()
        {
            //  Builder for the output.
            var builder = new StringBuilder();
            //  Go through each file.
            foreach (var filePath in SelectedItemPaths)
            {
                //  Count the lines.
                builder.AppendLine(string.Format("{0} - {1} Lines",
                  Path.GetFileName(filePath), File.ReadAllLines(filePath).Length));
            }
            //  Show the ouput.
            MessageBox.Show(builder.ToString());
        } 
    }
    }
