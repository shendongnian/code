    public MusicNote(int iPitch, string iNoteShape):base()
    {
    	pitch = iPitch;
    	noteShape = iNoteShape;
    	Location = new Point((pitch*40)-40, 100);
    	Size = new Size(40, 40);
    	//Bitmap bmp = new Bitmap(noteShape + ".png");
    	BackgroundImage = Image.FromFile(noteShape);
    	this.BackColor = Color.Transparent;
    	Image = Image;   //<- why assign Image to Image?
    	this.Visible = true;
    	this.BringToFront(); // <- try this line in the MusKey class instead, again red herring
    }
