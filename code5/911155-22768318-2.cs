    class MyClass
    {
       public static readonly PictureBox availablePic = new PictureBox();
       public static readonly PictureBox unavailablePic = new PictureBox();
       static MyClass()
       {
          // Initialize the picture boxes here.
          availablePic.Image = Image.FromFile("available.png");
       }
    ...
    }
