    Bitmap grayscaleImage = new Bitmap(inputImage.ImageSource);
                for (int x = 0; x < grayscaleImage.Width; x++)
                {
                    for (int y = 0; y < grayscaleImage.Height; y++)
                    {
                        byte[,] tempMatrix = inputImage.ImageGrayscale;
                        byte temp = tempMatrix[x, y];
                        Color tempColor = Color.FromArgb(255, temp, temp, temp);
                        grayscaleImage.SetPixel(x, y, tempColor);
                    }
                }
                picboxDisplay.Image = grayscaleImage;
