    String text = xtraReport1.GetCurrentColumnValue("Paczka_Notatki").ToString();
    
        string finalNote = "";
    	string[] notes = System.Text.RegularExpressions.Regex.Split(text, @"\d{1,}\.\smessage:(?<Message>[\D\s]+)");
    
    	foreach (string note in notes)
    	{
    		if (!String.IsNullOrEmpty(note) && finalNote.IndexOf(note) == -1)
    		finalNote += note;
        	}
    	xrTableCell3.Text = finalNote;
