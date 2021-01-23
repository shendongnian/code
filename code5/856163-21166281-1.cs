    public void Load(string path) 
    {
    
        foreach string s in path {
          using(Stream bmpStrm= System.IO.File.Open(s, System.IO.FileMode.Open ))
          {
             Image img = Image.FromStream(bmpStrm);
             b=new Bitmap(img);
             DoYourThang(b)
          }
    }
