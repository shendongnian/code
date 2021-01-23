        private CompositeCollection _treeNodeChildCollections;
		public CompositeCollection TreeNodeChildCollections
		{
			get
			{
				if (_treeNodeChildCollections == null)
				{
					_treeNodeChildCollections = new CompositeCollection();
					var cc1 = new CollectionContainer();
					cc1.Collection = Children;
					var cc2 = new CollectionContainer();
					cc2.Collection = TreeNodes;
					_treeNodeChildCollections.Add(cc1);
					_treeNodeChildCollections.Add(cc2);
				}
				return _treeNodeChildCollections;
			}
		}
