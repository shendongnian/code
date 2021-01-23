                using (var ms = new MemoryStream())
                {
                    image2.SaveJpeg(ms, image2.PixelWidth, image2.PixelHeight, 0, 100);
                    ms.Position = 0;
                    using (var oriStreamImageSource2 = new StreamImageSource(ms))
                    {
                        //Create the blurred version of original image
                        var blurEffect = new FilterEffect(oriStreamImageSource2)
                        {
                            Filters = new[] { new BlurFilter() { KernelSize = BlurLevel } }
                        };
                        var blendEffect1 = new FilterEffect(blurEffect)
                        {
                            Filters = new[] { new BlendFilter(oriStreamImageSource2, BlendFunction.Difference) }
                        };
                        //Create the Laplacian of the original image using the emboss filter
                        var embossEffect = new FilterEffect(oriStreamImageSource2)
                        {
                            Filters = new[] { new EmbossFilter(1.0f) }
                        };
                        //Add the result of blur with emboss filter
                        var blendEffect2 = new FilterEffect(blendEffect1)
                        {
                            Filters = new[] { new BlendFilter(embossEffect, BlendFunction.Add) }
                        };
                        //Perform a gray scale as we need just informations on radiance not colours
                        var grayScaleEffect = new FilterEffect(blendEffect2)
                        {
                            Filters = new[] { new GrayscaleFilter() }
                        };
                        using (var writableBitmapRenderer = new WriteableBitmapRenderer(grayScaleEffect, toneMap2))
                        {
                            toneMap2 = await writableBitmapRenderer.RenderAsync();
                         
                            blurEffect.Dispose();
                            blendEffect1.Dispose();
                            embossEffect.Dispose();
                            blendEffect2.Dispose();
                            grayScaleEffect.Dispose();
                        }
                    };
                }
