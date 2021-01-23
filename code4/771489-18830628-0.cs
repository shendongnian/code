                            // apply saturation filter to increase green intensity
                            var f1 = new SaturationCorrection(0.5f);
                            f1.ApplyInPlace(image);
                            var filter = new HSLFiltering();
                            filter.Hue = new IntRange(83, 189);         // all green (large range)
                            //filter.Hue = new IntRange(100, 120);      // light green (small range)
                            
                            // this will convert all pixels outside the range into gray-scale
                            //filter.UpdateHue = false;
                            //filter.UpdateLuminance = false;
                            // this will convert all pixels outside that range blank (filter.FillColor)
                            filter.Saturation = new Range(0.4f, 1);
                            filter.Luminance = new Range(0.4f, 1);
                            // apply the HSV filter to get only green pixels
                            filter.ApplyInPlace(image);
