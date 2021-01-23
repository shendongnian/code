            Image<Gray, Byte> gray1 = imgProcessed.Convert<Gray, Byte>().PyrDown().PyrUp();
            Image<Gray, Byte> cannyGray = gray1.Canny(120, 180);
            imgProcessed = cannyGray;
            LineSegment2D[] lines = imgProcessed.HoughLinesBinary(
                                    1,                  //Distance resolution in pixel-related units
                                    Math.PI / 45.0,     //Angle resolution measured in radians.
                                    50,                 //threshold
                                    100,                //min Line width
                                    1                   //gap between lines
                                    )[0];               //Get the lines from the first channel
