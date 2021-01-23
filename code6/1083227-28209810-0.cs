    class CustomEditor : CollectionEditor
    {
        public CustomEditor(Type type)
            : base(type)
        {
        }
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm collectionForm = base.CreateCollectionForm();
            collectionForm.Text = "My title";
            return collectionForm;
        }
    }
