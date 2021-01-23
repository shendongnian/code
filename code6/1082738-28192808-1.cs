    var Data = ...; // The original ItemCollection
	var DataExcess = new DataGrid().Items; // It isn't possible to use new ItemCollection();
	for(var i = 0; i < Data.Count; i++) {
		if(i > 13) {
			DataExcess.Add(Data[i]);
			continue;
		}
		// Otherwise print the row to the page using e.Graphics.DrawString(..)
	}
	if(DataExcess.Count > 0) {
		new Print(Some, Parameters, Here, ..., DataExcess).Print();
	}
