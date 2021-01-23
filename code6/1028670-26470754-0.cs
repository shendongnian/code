    public class NotifyingCollectionEditor : CollectionEditor
    {
        // Define a static event to expose the inner PropertyGrid's PropertyValueChanged event args...
        public static event EventHandler<PropertyValueChangedEventArgs> ElementChanged;
        // Inherit the default constructor from the standard Collection Editor...
        public NotifyingCollectionEditor(Type type) : base(type) { }
        // Override this method in order to access the containing user controls from the default Collection Editor form or to add new ones...
        protected override CollectionForm CreateCollectionForm()
        {
            // Getting the default layout of the Collection Editor...
            CollectionForm collectionForm = base.CreateCollectionForm();
            Form frmCollectionEditorForm = collectionForm as Form;
            TableLayoutPanel tlpLayout = frmCollectionEditorForm.Controls[0] as TableLayoutPanel;
            if (tlpLayout != null)
            {
                // Get a reference to the inner PropertyGrid and hook an event handler to it.
                if (tlpLayout.Controls[5] is PropertyGrid)
                {
                    PropertyGrid propertyGrid = tlpLayout.Controls[5] as PropertyGrid;
                    propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged);
                }
            }
            return collectionForm;
        }
        protected override object SetItems(object editValue, object[] value)
        {
            object ret_val = base.SetItems(editValue, value);
            // Fire our customized collection event...
            var evt = NotifyingCollectionEditor.ElementChanged;
            if (evt != null)
                evt(this, null);
            return ret_val;
        }
        void propertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            // Fire our customized collection event...
            var evt = NotifyingCollectionEditor.ElementChanged;
            if (evt != null)
                evt(this, e);
        }
    }
