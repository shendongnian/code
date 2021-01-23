	private void QueryBtn_Click(object sender, EventArgs e)
	{
		NewMethod();
	}
	private static void OnTimedEvent(object source, ElapsedEventArgs e)
	{   
		NewMethod();
	}
	private void NewMethod()
	{
		DCXOBJIterator it = null;
		DCXREQ req = null;
		DCXOBJ rp = null;
		DCXOBJ sps = null;
		DCXELM el = null;
		DCXOBJIterator spsIt = null;
		try
		{
			// Fill the query object
			rp = new DCXOBJ();
			sps = new DCXOBJ();
			el = new DCXELM();
			// Build the Scheduled procedure Step (SPS) item
			el.Init((int)DICOM_TAGS_ENUM.ScheduledStationAETitle);
			el.Value = StationNameEdit.Text;
			sps.insertElement(el);
		}
	}
