	protected override void OnCreate (Bundle bundle)
			listView.ItemClick+= delegate(object sender, AdapterView.ItemClickEventArgs position)
			{    
				String selectedFromList =(String) (listView.GetItemAtPosition(position.Position));
			    Intent i =new Intent(this,typeof(RedirectClass));
