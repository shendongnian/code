        string _selectedMovName = Convert.ToString(cbBookedSeatMovInfo.SelectedValue);
        string _selectedMovDate = Convert.ToString(cbBookedSeatMovDate.SelectedValue);
        string _selectedMovTime = Convert.ToString(cbBookedSeatMovTime.SelectedValue);
        //declare list of MovieRunTime and store your results 
        list<MovieRunTime> myList= movRunService.GetRunTimeOnNameDateAndTime(_selectedMovName, _selectedMovDate, _selectedMovTime);
       //check if your list is not null and if has items
       if (myLista != null && myLista.count > 0) {
       {
        MovieRunTime firstElement = myList[0];
        int _runTimeId = firstElement.IdValue;
        cbRow1.DataSource = seatService.GetRowsOnRunTime(_runTimeId);
        cbRow1.ValueMember = "id";
        cbRow1.DisplayMember = "rowId";
       }
