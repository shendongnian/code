    public class ColorDetails
    {
        public Hsv hueLowerLimit { get; set; }
        public Hsv hueUpperLimit { get; set; }
        
    }
            hueLowerLimit = new Hsv(hueLow, satLow, valLow);
            hueUpperLimit = new Hsv(hueHigh, satHigh, valHigh);
===================
    ColorDetails element = // add hue upperlimit and lower limit here
    Image<Gray, byte> filteredImage = null;
    //function to filter out a specified hue range 
    if (element.hueLowerLimit.Hue > element.hueUpperLimit.Hue)
    {
        filteredImage = hsvImage.InRange(element.hueLowerLimit, new Hsv(180, element.hueUpperLimit.Satuation, element.hueUpperLimit.Value))
        .Add(hsvImage.InRange(new Hsv(0, element.hueLowerLimit.Satuation, element.hueLowerLimit.Value), element.hueUpperLimit));
    }
    else
    {
        filteredImage = hsvImage.InRange(element.hueLowerLimit, element.hueUpperLimit);
    }
    /*                        
    //for debugging
    Image<Bgr, Byte> masked = new Image<Bgr, byte>(image.Size);
    image.Copy(masked, filteredImage);
    Console.WriteLine("Color Count : " + filteredImage.CountNonzero()[0]);
    CvInvoke.Imshow("out", masked);
    CvInvoke.WaitKey(0);
    */
    //this is the pixel count of a particular hue range
    filteredImage.CountNonzero()[0]
