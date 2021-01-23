            List<ImageSource> list = new List<ImageSource>();
            WindowCollection collection = Application.Current.Windows;
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(ImageSource));
            for (int i = 0; i < collection.Count; i++)
            {
                byte[] imgBytes = ScreenShot.GetJpgImage(collection[i], 1, 90);
                ImageSource img = (ImageSource)tc.ConvertFrom(imgBytes);
                list.Add(img);
            }
