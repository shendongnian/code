        public Constructor()
        {
            this.FieldChooserOpening += thisObject_FieldChooserOpening;
        }
        void thisObject_FieldChooserOpening(object sender, Infragistics.Windows.DataPresenter.Events.FieldChooserOpeningEventArgs e)
        {
            e.FieldChooser.FieldGroupSelectorVisibility = Visibility.Collapsed;
        }
