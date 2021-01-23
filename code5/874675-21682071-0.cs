        private void BuildTree()
        {
            tvLevels .Nodes.Clear();
            _svsCentralDataContext = new SVSCentralDataContext();
            List<DataAccessLayer.Level> items = DataAccessLayer.Levels.GetLevels(_intSurveyId).ToList();
            List<DataAccessLayer.Level> rootItems = items.FindAll(p => p.ParentLevelId == null);
            foreach (DataAccessLayer.Level item in rootItems)
            {
                var tvi = new TreeNode(item.Description, item.Id.ToString(CultureInfo.InvariantCulture) );
                BuildChildNodes(tvi, items, item.Id);
                tvLevels.Nodes.Add(tvi);
            }
        }
        private void BuildChildNodes(TreeNode parentNode, List<DataAccessLayer.Level> items, int parentId)
        {
            List<DataAccessLayer.Level> children = items.FindAll(p => p.ParentLevelId == parentId).ToList();
            foreach (DataAccessLayer.Level item in children)
            {
                var tvi = new TreeNode(item.Description, item.Id.ToString(CultureInfo.InvariantCulture));
                parentNode.ChildNodes.Add(tvi);
                BuildChildNodes(tvi, items, item.Id);
            }
        }
