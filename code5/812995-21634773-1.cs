        public override void OnActivityCreated(Bundle savedInstanceState){ 
            base.OnActivityCreated(savedInstanceState);    
            // Get Data from Server
            string jsonToSend;
            DataBaseSendObject dbs = new DataBaseSendObject ();
            dbs.CommandId = 4;
            dbs.AddParameter ("@UserId", Localpreference.GetUserId (Application.Context), 2);
            jsonToSend = dbs.JsonSerialization ();
            object objRecieved;
            objRecieved = DatabaseConnection.SendToServer(dbs);
            // Bringing Items into the right Format
            list_items = BM_JsonSerializer.GetListFromJson<TwoLineItem> (objRecieved.ToString ());
            TwoLineItem createNewGroupe = new TwoLineItem ();
            createNewGroupe.Id = 0;
            createNewGroupe.FirstLine = "Create new Group";
            createNewGroupe.SecondLine = "";
            ListAdapter = new TwoLineItemAdapter(Activity, list_items);
            //SetListShown (true);
            // Adding data to the View with an Adapter
            //ListView lst = rootView.FindViewById<ListView> (Resource.Id.list);
            //lst.Adapter = new TwoLineItemAdapter(this.Activity, list_itemsss);
            //lst.ItemClick += OnListItemClick;  // to be defined
          
        }
