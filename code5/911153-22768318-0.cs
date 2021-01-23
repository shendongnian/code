    class MyClass
    {
       public static readonly PictureBox availablePic = new PictureBox();
       public static readonlyPictureBox unavailablePic = new PictureBox();
       static MyClass()
       {
          // Initialize the picture boxes here.
          availablePic.Image = Image.Load("available.png");
       }
    ...
    }
