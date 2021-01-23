        BitmapImage rotateImage(string filename,int angle)
        {
            WIA.ImageFile img = new WIA.ImageFile();
            img.LoadFile(filename);
            WIA.ImageProcess IP = new WIA.ImageProcess();
            Object ix1 = (Object)"RotateFlip";
            WIA.FilterInfo fi1 = IP.FilterInfos.get_Item(ref ix1);
            IP.Filters.Add(fi1.FilterID, 0);
            Object p1 = (Object)"RotationAngle";
            Object pv1 = (Object)angle;
            IP.Filters[1].Properties.get_Item(ref p1).set_Value(ref pv1);
            img = IP.Apply(img);
            File.Delete(filename);
            img.SaveFile(filename);
            BitmapImage imagetemp = new BitmapImage();
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                imagetemp.BeginInit();
                imagetemp.CacheOption = BitmapCacheOption.OnLoad;
                imagetemp.StreamSource = stream;
                imagetemp.EndInit();
            }
            return imagetemp;
        }
