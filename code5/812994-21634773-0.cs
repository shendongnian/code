        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);            
            SetHasOptionsMenu(true); 
             if (_adapter == null)
                _adapter = new SkillAdapter(Activity, MyApp, MyCharacter); //MyCustom Adapter class.
            ListAdapter = _adapter;
            ListView.OnItemLongClickListener = _adapter;               
        }
