            /*
             * -----------------------------------------------------------------------------------
             * Step 3:  Resize the gray image by using smoothing on it.
             *          This makes the image-data more smooth for further processing
             * -----------------------------------------------------------------------------------
             * */
            var width = Convert.ToInt32(this.Params["Width"]);
            var smoothWidth = Convert.ToInt32(width / 150F);
            grayShadeMatrix = grayShadeMatrix.Resize(width, Convert.ToInt32(width * (float)ySize / (float)xSize), Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            grayShadeMatrix = grayShadeMatrix.SmoothBlur(smoothWidth, smoothWidth);
            #endregion
            #region Step 4: Create HeatMap by applying gradient color
            /*
             * -----------------------------------------------------------------------------------
             * Step 4:  Create the heatmap by using the value of the every point as hue-angle for the color
             *          This way the color can be calculated very quickly. Also applies a log-function
             *          on the value, to make the lower values visible too
             * -----------------------------------------------------------------------------------
             * */
            this.MaxHueValuePerValuePoint = MAX_HUE_VALUE / this.MaxValue;
            this.MaxHueValuePreCompiled = Math.Log(MAX_HUE_VALUE, ScalaLogBase);
            var grayShadeMatrixConverted = grayShadeMatrix.Convert<byte>(GetHueValue);
            
            // Create the hsv image
            var heatMapHsv = new Image<Hsv, byte>(grayShadeMatrixConverted.Width, grayShadeMatrixConverted.Height, new Hsv());
            heatMapHsv = heatMapHsv.Max(255); // Set each color-channel to 255 by default (hue: 255, sat: 255, val: 255)
            heatMapHsv[0] = grayShadeMatrixConverted; // Now set the hue channel to the calculated hue values
            // Convert hsv image back to rgb, for correct display
            var heatMap = new Image<Rgba, byte>(grayShadeMatrixConverted.Width, grayShadeMatrixConverted.Height, new Rgba());
            CvInvoke.cvCvtColor(heatMapHsv.Ptr, heatMap.Ptr, Emgu.CV.CvEnum.COLOR_CONVERSION.CV_HSV2RGB);
            #endregion
