     public InteropBitmapHelper(ColorSpace colorSpace, int bpp, int width, int height, uint byteCount)
            {
                _currentColorSpace = colorSpace;
                _pixelFormat = GetPixelFormat(colorSpace, bpp);
    
                if (_pixelFormat == PixelFormats.Rgb24 || _pixelFormat == PixelFormats.Rgb48 || _pixelFormat == PixelFormats.Bgr32 ||
                    _pixelFormat == PixelFormats.Bgr24 || _pixelFormat == PixelFormats.Bgr565 ||
                    _pixelFormat == PixelFormats.Gray16 || _pixelFormat == PixelFormats.Gray8)
                {
                    int strideWidth = (width % 4 == 0) ? width : width - width % 4 + 4;
                    if (byteCount != strideWidth * height * (_pixelFormat.BitsPerPixel / 8))
                    {
                        strideWidth = width;
                    }
                    _stride = strideWidth * _pixelFormat.BitsPerPixel / 8;
    
                    _byteCount = (uint)((_stride) * height * ((short)bpp).NumberOfBytes());
    
                    ColorFileMapping = CreateFileMapping(new IntPtr(-1), IntPtr.Zero, 0x04, 0, _byteCount, null);
    
                    if (ColorFileMapping == IntPtr.Zero)
                    {
                        var res=GetLastError();
                        IPDevLoggerWrapper.Error("Could not generate InteropBitmap "+res);
                        return;
                    }
                    ViewerImageData = MapViewOfFile(ColorFileMapping, 0xF001F, 0, 0, _byteCount);
                    InteropBitmap = Imaging.CreateBitmapSourceFromMemorySection(ColorFileMapping,
                                                                                width,
                                                                                height,
                                                                                _pixelFormat,
                                                                                _stride,
                                                                                0) as InteropBitmap;
                }
                else
                {
                    LoggerWrapper.Error("The image format is not supported");
                    return;
                }
            }
