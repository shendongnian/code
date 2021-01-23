    public static List<Point> FindBitmapsEntry(Bitmap sourceBitmap, Bitmap serchingBitmap)
        {
            #region Проверка аргументов
            if (sourceBitmap == null || serchingBitmap == null)
                throw new ArgumentNullException();
            if (sourceBitmap.PixelFormat != serchingBitmap.PixelFormat)
                throw new ArgumentException("Различный формат изображений.");
            if (sourceBitmap.Width < serchingBitmap.Width || sourceBitmap.Height < serchingBitmap.Height)
                throw new ArgumentException("Размер искомого изображения должен быть больше иходного.");
            #endregion
            var pixelFormatSize = Image.GetPixelFormatSize(sourceBitmap.PixelFormat)/8;
            
            // Копируем в массив исходное изображение
            var sourceBitmapData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                ImageLockMode.ReadOnly, sourceBitmap.PixelFormat);
            var sourceBitmapBytesLength = sourceBitmapData.Stride * sourceBitmap.Height;
            var sourceBytes = new byte[sourceBitmapBytesLength];
            Marshal.Copy(sourceBitmapData.Scan0, sourceBytes, 0, sourceBitmapBytesLength);
            sourceBitmap.UnlockBits(sourceBitmapData);
            
            // Копируем в массив искомое изображение
            var serchingBitmapData =
                serchingBitmap.LockBits(new Rectangle(0, 0, serchingBitmap.Width, serchingBitmap.Height),
                    ImageLockMode.ReadOnly, serchingBitmap.PixelFormat);
            var serchingBitmapBytesLength = serchingBitmapData.Stride * serchingBitmap.Height;
            var serchingBytes = new byte[serchingBitmapBytesLength];
            Marshal.Copy(serchingBitmapData.Scan0, serchingBytes, 0, serchingBitmapBytesLength);
            serchingBitmap.UnlockBits(serchingBitmapData);
            var pointsList = new List<Point>();
            
            // Поиск вхождений
            // Уменьшение зоны поиска по высоте искомого рисунка
            // вследствии того что он тупо туда не поместиться
            // +1 для начала поиска вохождения рисунка в случае если он находиться на самом краю исходного изображения
            // sourceBitmap.Height - serchingBitmap.Height + 1
            // (тоже самое для ширины рисунка)
            for (var mainY = 0; mainY < sourceBitmap.Height - serchingBitmap.Height + 1; mainY++)
            {
                var sourceY = mainY * sourceBitmapData.Stride;
                for (var mainX = 0; mainX < sourceBitmap.Width - serchingBitmap.Width + 1; mainX++)
                {// mainY и mainX - кординаты пикселей исходного изображения
                    // sourceY + sourceX = указатель на байт в массиве исходного изображения с которого начинается пиксель
                    var sourceX = mainX*pixelFormatSize;
                    
                    var isEqual = true;
                    for (var c = 0; c < pixelFormatSize; c++)
                    {// проход по байтам пикселя
                        if (sourceBytes[sourceX + sourceY + c] == serchingBytes[c]) 
                            continue;
                        isEqual = false;
                        break;
                    }
                    
                    if (!isEqual) continue;
                    var isStop = false;
                    // нашлось первое совпадение пикселя и теперь продолжается "внутренне" сравнение
                    for (var secY = 0; secY < serchingBitmap.Height; secY++)
                    {
                        var serchY = secY * serchingBitmapData.Stride;
                        var sourceSecY = (mainY + secY)*sourceBitmapData.Stride;
                            
                        for (var secX = 0; secX < serchingBitmap.Width; secX++)
                        {// secX и secY - кординаты искомого изображения
                            // serchX + serchY = указатель на байт в массиве искомого изображения с которого начинается пиксель
                            
                            var serchX = secX*pixelFormatSize;
                            // sourceSecY + sourceSecX = указатель на байт в массиве исходного изображения с которого начинается пиксель
                            // относительно прохода по искомому изображению
                            var sourceSecX = (mainX + secX)*pixelFormatSize;
                            for (var c = 0; c < pixelFormatSize; c++)
                            {// проход по байтам пикселя
                                if (sourceBytes[sourceSecX + sourceSecY + c] == serchingBytes[serchX + serchY + c]) continue;
                                
                                // не совпало поэтому прерываемся
                                isStop = true;
                                break;
                            }
                            if (isStop) break;
                        }
                        if (isStop) break;
                    }
                    if (!isStop)
                    {// нашлось искомое изображение
                        pointsList.Add(new Point(mainX, mainY));
                    }
                }
            }
            
            return pointsList;
        }
