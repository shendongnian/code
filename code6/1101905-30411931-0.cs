         Image<Gray, byte> grayframe = capture.RetrieveBgrFrame().Convert<Gray, byte>();
        static string HCSUpperBody = "haarcascade_upperbody.xml";
          var faces = grayframe.DetectHaarCascade(hcBodyDetector, 1.2, 6, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size())[0];
                     
                    
                         foreach (var face in faces)
                         {
                             image.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);
                         }
