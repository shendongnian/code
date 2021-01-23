    ....
     Image<Gray, Byte> res = DetectSkin(img, new Ycc(0,0,0), new Ycc(150,150,150));
     ImageView.Image = res.ToBitmap();
    ....
    
       
    
        Image<Gray, byte> DetectSkin(Image<Bgr, byte> Img, IColor min, IColor max)
                {
                    Image<Ycc, Byte> currentYCrCbFrame = Img.Convert<Ycc, Byte>();
                    //Image<Hsv, Byte> currentHsvFrame = Img.Convert<Hsv, Byte>();
                    Image<Gray, byte> skin = new Image<Gray, byte>(Img.Width, Img.Height);
                    skin = currentYCrCbFrame.InRange((Ycc)min, (Ycc)max);
                    StructuringElementEx rect_12 = new StructuringElementEx(12, 12, 6, 6, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
                    CvInvoke.cvErode(skin, skin, rect_12, 1);
                    StructuringElementEx rect_6 = new StructuringElementEx(6, 6, 3, 3, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
                    CvInvoke.cvDilate(skin, skin, rect_6, 2);
                    return skin;
                }
