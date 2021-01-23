        public static void DeleteTreeNodeChild(BehaviorTree.Choice parentNode, BehaviorTree.Node childNode) {
            parentNode.Children.Remove(childNode);
        }
        public static void DeleteTreeNodeChild(BehaviorTree.Optional parentNode, BehaviorTree.Node childNode) {
            Debug.Assert(parentNode.Child == childNode);
            parentNode.Child = null;
        }
        public static void DeleteTreeNodeChild(BehaviorTree.Repetition parentNode, BehaviorTree.Node childNode) {
            Debug.Assert(parentNode.Child == childNode);
            parentNode.Child = null;
        }
        public static void DeleteTreeNodeChild(BehaviorTree.Sequence parentNode, BehaviorTree.Node childNode) {
            parentNode.Children.Remove(childNode);
        }
        private static DynamicDispatcher _deleteTreeNodeChildDynamicDispatcher;
        public static void DeleteTreeNodeChild(BehaviorTree.Node parentNode, BehaviorTree.Node childNode) {
            if (_deleteTreeNodeChildDynamicDispatcher == null) {
                _deleteTreeNodeChildDynamicDispatcher = new DynamicDispatcher();
            }
            _deleteTreeNodeChildDynamicDispatcher.Dispatch<Object>(null, parentNode, childNode);
        }
