     public UIImage ResizeImage(UIImage sourceImage, float width, float height)
            {
                UIGraphics.BeginImageContext(new SizeF(width, height));
                sourceImage.Draw(new RectangleF(0, 0, width, height));
                var resultImage = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();
                return resultImage;
            }
