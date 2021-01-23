       ObservableCollection<EditablePurchase> Purchases = new ObservableCollection<EditablePurchase>()
            {
                new EditablePurchase {FieldA = "Field_A_1", FieldB = "Field_B_1", Edited = UpdateAction},
                new EditablePurchase {FieldA = "Field_A_2", FieldB = "Field_B_2", Edited = UpdateAction}
            };
        Purchases.CollectionChanged += Purchases_CollectionChanged;
        private void Purchases_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (EditablePurchase item in e.NewItems)
                    item.Edited = UpdateAction;
        }
        void UpdateAction(Purchase purchase)
        {
            // Save XML
        }
