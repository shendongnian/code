        private void AddMenu(string menuName, int id, int parentId, string fileName)
        {
            BarSubItem subitem = CreateSubItem(menuName, id, fileName);
            if (parentId != 0)
            {
                BarSubItem parentItem = ribbon.Items.FindById(parentId) as BarSubItem;
                parentItem.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(subitem));
            }
            else
            {                
                menuBarSubItem.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(subitem));
            }
        }
        private BarSubItem CreateSubItem(string menuName, int id, string fileName)
        {
            BarSubItem subitem = new BarSubItem(ribbon.Manager, menuName);
            subitem.Id = id;
            if (!string.IsNullOrEmpty(fileName))
                subitem.Glyph = System.Drawing.Image.FromFile("file.png");
            return subitem;
        }
        private void AddMenuItem(string menuName, int id, int parentId, string fileName)
        {
            BarButtonItem buttonItem = new BarButtonItem(ribbon.Manager, menuName);
            buttonItem.Id = id;
            buttonItem.Tag = fileName;
            buttonItem.ItemClick += buttonItem_ItemClick;
            if (!string.IsNullOrEmpty(fileName))
                buttonItem.Glyph = System.Drawing.Image.FromFile("file.png");
            if (parentId != 0)
            {
                BarSubItem parentItem = ribbon.Items.FindById(parentId) as BarSubItem;
                parentItem.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(buttonItem));
            }
            else
            {
                menuBarSubItem.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(buttonItem));                
            }
        }
