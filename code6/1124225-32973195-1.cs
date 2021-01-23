    public class Calibration
    {
        static void Main(string[] args)
        {
            // chessboard pattern size
            Size patternSize = new Size(9, 7);
            
            // for each image, have one Image object and one VectorOfPoints
            // for many images have a List of each
            List<VectorOfPoint> corners = new List<VectorOfPoint>();
            List<Image<Gray, Byte>> images = new List<Image<Gray, byte>>();
            // get paths to image files
            string[] imageFiles = Directory.GetFiles(@"C:\your\directory", "*.jpg");
            
            // for every image
            foreach (string imageFile in imageFiles)
            {
                // create new image object from file path
                var image = new Image<Gray, byte>(imageFile);
                images.Add(image);
                // create new list of corner points
                var cornerPoints = new VectorOfPoint();
                corners.Add(cornerPoints);
                // find chessboard corners
                bool result = CvInvoke.FindChessboardCorners(image, patternSize, cornerPoints);
                // some debug output
                Console.WriteLine("=== " + Path.GetFileName(imageFile) + " === " + result);
                if (!result)
                {
                    continue;
                }
                // list points
                foreach (Point cornerPoint in cornerPoints.ToArray())
                {
                    Console.WriteLine(cornerPoint.X + ", " + cornerPoint.Y);
                }
            }
            Console.ReadLine();
        }
    }
