    MusicNote musNote = null;
    protected void MusKey_MouseUp(object sender, EventArgs e)
    {
    	timer.Stop();
    	txt1.Text = Convert.ToString(musicNote)+ " up"; //To test if musicNote refers to the correct pitch integer.
    	txt2.Text = Convert.ToString(duration);         //To test the number of ticks.
    	timer.Enabled = false;
    	string bNoteShape = "";
    
    	if (duration < 5) bNoteShape = "Crotchet.png";
    	if (duration > 5) bNoteShape = "minim.png";
    
        //Remove the previous musNote Picture box before adding another one:
        if (musNote != null) Form1.Ms.Controls.Remove(musNote);
    	musNote = new MusicNote(this.musicNote, bNoteShape);
    
    	Form1.Ms.Controls.Add(musNote);
        
        //maybe a red herring, but just encase make sure picture box is on top:
        musNote.BringToFront()
    }
