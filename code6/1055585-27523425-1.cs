    private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            Taxonomy selectedObject = (Taxonomy)spinner.Adapter.GetItem(e.Position);
			
			//rest of code using selected object.
        }
