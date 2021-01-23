    class DoNotCareVisitor<T> : MyVisitor<T> {
        void GenericVisit(TreeStructure<T> tree) {  
            //.. do whatever 
        }
        public void Visit(TreeStructure<T> tree) {
            GenericVisit(tree);
        }
        public void Visit(SpecialTree<T> tree) {
            GenericVisit(treeStructure);
        }
    }
