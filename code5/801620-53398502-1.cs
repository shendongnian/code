    public static class EnumerableExtensions
    {
        public static IEnumerable<TreeNode<T, TKey>> ToTree<T, TKey>(
            this IList<T> collection,
            Func<T, TKey> itemIdSelector,
            Func<T, TKey> parentIdSelector)
        {
            var rootNodes = new List<TreeNode<T, TKey>>();
            var collectionHash = collection.ToLookup(parentIdSelector);
            //find root nodes
            var parentIds = collection.Select(parentIdSelector);
            var itemIds = collection.Select(itemIdSelector);
            var rootIds = parentIds.Except(itemIds);
            foreach (var rootId in rootIds)
            {
                rootNodes.AddRange(
                    GetTreeNodes(
                        itemIdSelector,
                        collectionHash,
                        rootId)
                    );
            }
            return rootNodes;
        }
        private static IEnumerable<TreeNode<T, TKey>> GetTreeNodes<T, TKey>(
            Func<T, TKey> itemIdSelector,
            ILookup<TKey, T> collectionHash,
            TKey parentId)
        {
            return collectionHash[parentId].Select(collectionItem => new TreeNode<T, TKey>
            {
                ParentId = parentId,
                Item = collectionItem,
                Children = GetTreeNodes(
                    itemIdSelector,
                    collectionHash,
                    itemIdSelector(collectionItem))
            });
        }
    }
