	//Get the a musicians BusinessBaseList
	MusiciansList musicians = MusiciansList.GetList();
	//Use the ObjectAdapter to transform the list into
	//a DataSet
	ObjectAdapter adapter = new ObjectAdapter();
	DataSet ds = new DataSet();
	adapter.Fill(ds, musicians);
	//Bind the DataSet to the musician’s 
	//DropDownList
	ddMusicians.DataSource = ds.Tables[0];
	ddMusicians.DataTextField = "LastName";
	ddMusicians.DataValueField = "Id";
	ddMusicians.DataBind();
