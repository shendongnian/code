	protected override void OnCreate (Bundle bundle)
			listView.ItemClick+= delegate(object sender, AdapterView.ItemClickEventArgs position)
			{    
				String selectedFromList =(String) (listView.GetItemAtPosition(position.Position));
			    Intent i =new Intent(this,typeof(RedirectClass));
    //	        i.PutExtra("key",selectedFromList);
    //			StartActivity(i);
				//int pos=Convert.ToInt32(position);
				//ListView Clicked item value
				//string  itemValue    =(string)listView.GetItemAtPosition(pos);
				//Toast.MakeText(this," position is "   +itemValue,ToastLength.Long).Show();
			};
		}
	}
