    public class MyDetailViewGeneratorUpdater : ModelNodesGeneratorUpdater<ModelDetailViewLayoutNodesGenerator> 
    {
        public override void UpdateNode(ModelNode node) 
        {
            IModelDetailViewLayout layout = node as IModelDetailViewLayout;
            IModelDetailView detailView = (IModelDetailView)layout.Parent;
            if (!XafTypesInfo.Instance.FindTypeInfo(typeof(MyBase)).IsAssignableFrom(detailView.ModelClass.TypeInfo)) 	return;
            foreach (IModelDetailViewLayoutElement element in layout)
                UpdateLayoutItems(element, detailView.Items, XafTypesInfo.Instance.FindTypeInfo(typeof(MyBase)).FindMember("Description"));
        }
    
        private void UpdateLayoutItems(IModelDetailViewLayoutElement element, IModelDetailViewItems items, IMemberInfo member) {
            IModelLayoutItem item = element as IModelLayoutItem;
            IModelLayoutGroup group = element as IModelLayoutGroup;
            if(group != null){
                foreach(IModelDetailViewLayoutElement element1 in group)
                UpdateLayoutItems(element1, items, member);
            }
            else if (item != null) {
                RemoveFromGroup(item); // you just need to code this bit of magic
            }
        }
    }
