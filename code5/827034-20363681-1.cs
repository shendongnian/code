         static MusicStaff ms;
         statuc MusicNote musNote 
    
    private void Form1_Load(object sender, EventArgs e)
    {
        ms = new MusicStaff();
        panel2.Controls.Add(ms);
    
        //Test of Music Note
        musNote = new MusicNote(1, "");
        ms.Controls.Add(musNote);
    public static MusicStaff Ms
    { 
       get {return ms; }
    }
 
    public static MusicNote Mn
    { 
       get {return ms; }
    }
