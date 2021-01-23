    public void Load(string path) 
    {
    
        foreach s in path {
          using(Stream bmpStrm= System.IO.File.Open(s, System.IO.FileMode.Open ))
          {
             Image img = Image.FromStream(bmpStrm);
             b=new Bitmap(img);
             DoYourThang(b)
          }
    }
