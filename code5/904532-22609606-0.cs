    public class testEmguCV : MonoBehaviour
    {
        private Capture capture;
        
        void Start() 
        {
            capture = new Capture();
        }
        void Update()
        {
            Image<Gray, Byte> currentFrame = capture.QueryGrayFrame();
            Bitmap bitmapCurrentFrame = currentFrame.ToBitmap();
            MemoryStream m = new MemoryStream();
            bitmapCurrentFrame.Save(m, bitmapCurrentFrame.RawFormat);
            Texture2D camera = new Texture2D(400, 400);
            if (currentFrame != null)
            {
                camera.LoadImage(m.ToArray());
                renderer.material.mainTexture = camera;
            }
         }
    }
