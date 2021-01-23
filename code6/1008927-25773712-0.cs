    ListView listView = (ListView)findViewById(R.id.LocationsList);
    lv.setOnItemClickListener(new OnItemClickListener()
    {
        @Override 
        public void onItemClick(AdapterView<?> arg0, View ItemView,int position, long arg3)
        { 
            // ItemView is the view of the list item that was clicked
            // since u said there will be 5 text views i.e. fixed number of text views below code seemb to be reasonable.
            // if the number of text is varying then better approach would be to get all the child nodes and proceed
            TextView txt1 = (TextView )findViewById(R.id.TextView1);
            ...
            ...
            TextView txt5 = (TextView )findViewById(R.id.TextView5);
        }
    });
