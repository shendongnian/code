        private double[,] TransformaImagemEmArray(System.Drawing.Bitmap imagem) {
            // Transforma a imagem de entrada em um array de doubles
            // com os valores grayscale da imagem
            BitmapData bitmap_data = imagem.LockBits(new System.Drawing.Rectangle(0,0,_foto_franjas_original.Width,_foto_franjas_original.Height),
                                                ImageLockMode.ReadOnly, _foto_franjas_original.PixelFormat);
            int pixelsize = System.Drawing.Image.GetPixelFormatSize(bitmap_data.PixelFormat)/8;
            IntPtr pointer = bitmap_data.Scan0;
            int nbytes = bitmap_data.Height * bitmap_data.Stride;
            byte[] imagebytes = new byte[nbytes];
            System.Runtime.InteropServices.Marshal.Copy(pointer, imagebytes, 0, nbytes);
            double red;
            double green;
            double blue;
            double gray;
            var _grayscale_array = new Double[bitmap_data.Height, bitmap_data.Width];
            if (pixelsize >= 3 ) {
                for (int I = 0; I < bitmap_data.Height; I++) {
                    for (int J = 0; J < bitmap_data.Width; J++ ) {
                        int position = (I * bitmap_data.Stride) + (J * pixelsize);
                        blue = imagebytes[position];
                        green = imagebytes[position + 1];
                        red = imagebytes[position + 2];
                        gray = 0.299 * red + 0.587 * green + 0.114 * blue;
                        _grayscale_array[I,J] = gray;
                    }
                }
            }
            _foto_franjas_original.UnlockBits(bitmap_data);
            return _grayscale_array;
        }
