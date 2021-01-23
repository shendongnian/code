    static List<Bitmap> brickImage = new List<Bitmap>();
    private static void myFunc()
    {
        brickImage.Add(new Bitmap("Enter Image Path for red"));
        brickImage.Add(new Bitmap("Enter Image Path for green"));
        brickImage.Add(new Bitmap("Enter Image Path for blue"));
        ....
    
        foreach (Bitmap bmp in brickImage)
        {
            //Do whatever you want to do.
        }
    }
