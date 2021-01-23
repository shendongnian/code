        [Editor("System.Windows.Forms.Design.StringCollectionEditor, " +
            "System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ComboBox.ObjectCollection Items
        {
            get
            {
                return baseComboBox.Items;
            }
            set
            {
                baseComboBox.Items.Clear();
                baseComboBox.Items.AddRange(value.Cast<object>().ToArray());
            }
        }
