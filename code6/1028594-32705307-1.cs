        private void CreateBaseDataSet()
        {
            _baseDataSet = new DicomAttributeCollection();
            //Sop Common
            _baseDataSet[DicomTags.SopClassUid].SetStringValue(SopClass.SecondaryCaptureImageStorageUid);
            ////Patient
            //_baseDataSet[DicomTags.PatientId].SetStringValue(_parent.PatientId);
            //_baseDataSet[DicomTags.PatientsName].SetStringValue(String.Format("{0}^{1}^{2}^^",
            //                                                                  _parent.LastName, _parent.FirstName, _parent.MiddleName));
            //_baseDataSet[DicomTags.PatientsBirthDate].SetDateTime(0, _parent.Dob);
            //_baseDataSet[DicomTags.PatientsSex].SetStringValue(_parent.Sex.ToString());
            ////Study
            //_baseDataSet[DicomTags.StudyInstanceUid].SetStringValue(DicomUid.GenerateUid().UID);
            //_baseDataSet[DicomTags.StudyDate].SetDateTime(0, _parent.StudyDate);
            //_baseDataSet[DicomTags.StudyTime].SetDateTime(0, _parent.StudyTime);
            //_baseDataSet[DicomTags.AccessionNumber].SetStringValue(_parent.AccessionNumber);
            //_baseDataSet[DicomTags.StudyDescription].SetStringValue(_parent.StudyDescription);
            //Patient
            _baseDataSet[DicomTags.PatientId].SetStringValue("PIDEEL");
            _baseDataSet[DicomTags.PatientsName].SetStringValue(String.Format("Moray^Eel^X-Ray"));
            //_baseDataSet[DicomTags.PatientsAddress].SetString (0,"Hubertus");
            //_baseDataSet[DicomTags.PatientsBirthDate].SetDateTime(0, DateTime.Now);
            //_baseDataSet[DicomTags.PatientsBirthDate].SetString(0, "19550512");
            _baseDataSet[DicomTags.PatientsSex].SetStringValue("O");
            //Study
            _baseDataSet[DicomTags.StudyInstanceUid].SetStringValue(DicomUid.GenerateUid().UID);
            _baseDataSet[DicomTags.StudyDate].SetDateTime(0, DateTime.Now);
            _baseDataSet[DicomTags.StudyTime].SetDateTime(0, DateTime.Now);
            _baseDataSet[DicomTags.AccessionNumber].SetStringValue("ACCEEL");
            _baseDataSet[DicomTags.StudyDescription].SetStringValue("X-Ray of a Moray Eel");
            _baseDataSet[DicomTags.ReferringPhysiciansName].SetNullValue();
            _baseDataSet[DicomTags.StudyId].SetNullValue();
            //Series
            _baseDataSet[DicomTags.SeriesInstanceUid].SetStringValue(DicomUid.GenerateUid().UID);
            _baseDataSet[DicomTags.Modality].SetStringValue("OT");
            _baseDataSet[DicomTags.SeriesNumber].SetStringValue("1");
            //SC Equipment
            _baseDataSet[DicomTags.ConversionType].SetStringValue("WSD");
            //General Image
            _baseDataSet[DicomTags.ImageType].SetStringValue(@"DERIVED\SECONDARY");
            _baseDataSet[DicomTags.PatientOrientation].SetNullValue();
            _baseDataSet[DicomTags.WindowWidth].SetStringValue("");
            _baseDataSet[DicomTags.WindowCenter].SetStringValue("");
            //Image Pixel
            if (rbMonoChrome.Checked )
            {
                    _baseDataSet[DicomTags.SamplesPerPixel].SetInt32(0, 1);
                    _baseDataSet[DicomTags.PhotometricInterpretation].SetStringValue("MONOCHROME2");
                    _baseDataSet[DicomTags.BitsAllocated].SetInt32(0, 8);
                    _baseDataSet[DicomTags.BitsStored].SetInt32(0, 8);
                    _baseDataSet[DicomTags.HighBit].SetInt32(0, 7);
                    _baseDataSet[DicomTags.PixelRepresentation].SetInt32(0, 0);
                    _baseDataSet[DicomTags.PlanarConfiguration].SetInt32(0, 0);
            }
            if (rbColor.Checked)
            {
                    _baseDataSet[DicomTags.SamplesPerPixel].SetInt32(0, 3);
                    _baseDataSet[DicomTags.PhotometricInterpretation].SetStringValue("RGB");
                    _baseDataSet[DicomTags.BitsAllocated].SetInt32(0, 8);
                    _baseDataSet[DicomTags.BitsStored].SetInt32(0, 8);
                    _baseDataSet[DicomTags.HighBit].SetInt32(0, 7);
                    _baseDataSet[DicomTags.PixelRepresentation].SetInt32(0, 0);
                    _baseDataSet[DicomTags.PlanarConfiguration].SetInt32(0, 0);
            }
        }
        private DicomFile ConvertImage(Bitmap image, int instanceNumber)
        {
            DicomUid sopInstanceUid = DicomUid.GenerateUid();
            string fileName = @"C:\test.dcm";// String.Format("{0}.dcm", sopInstanceUid.UID);
            //fileName = System.IO.Path.Combine(_tempFileDirectory, fileName);
            DicomFile dicomFile = new DicomFile(fileName, new DicomAttributeCollection(), _baseDataSet.Copy());
            //meta info
            dicomFile.MediaStorageSopInstanceUid = sopInstanceUid.UID;
            dicomFile.MediaStorageSopClassUid = SopClass.SecondaryCaptureImageStorageUid;
            //General Image
            dicomFile.DataSet[DicomTags.InstanceNumber].SetInt32(0, instanceNumber);
            DateTime now = Platform.Time;
            DateTime time = DateTime.MinValue.Add(new TimeSpan(now.Hour, now.Minute, now.Second));
            //SC Image
            dicomFile.DataSet[DicomTags.DateOfSecondaryCapture].SetDateTime(0, now);
            dicomFile.DataSet[DicomTags.TimeOfSecondaryCapture].SetDateTime(0, time);
            //Sop Common
            dicomFile.DataSet[DicomTags.InstanceCreationDate].SetDateTime(0, now);
            dicomFile.DataSet[DicomTags.InstanceCreationTime].SetDateTime(0, time);
            dicomFile.DataSet[DicomTags.SopInstanceUid].SetStringValue(sopInstanceUid.UID);
            //int rows, columns;
            //Image Pixel
            if (rbMonoChrome.Checked)
            {
                dicomFile.DataSet[DicomTags.PixelData].Values = GetMonochromePixelData(image, out rows, out columns);
            }
            if (rbColor.Checked)
            {
                dicomFile.DataSet[DicomTags.PixelData].Values = GetColorPixelData(image, out rows, out columns);
            }
            //Image Pixel
            dicomFile.DataSet[DicomTags.Rows].SetInt32(0, rows);
            dicomFile.DataSet[DicomTags.Columns].SetInt32(0, columns);
            return dicomFile;
        }
        private static byte[] GetMonochromePixelData(Bitmap image, out int rows, out int columns)
        {
            rows = image.Height;
            columns = image.Width;
            //At least one of rows or columns must be even.
            if (rows % 2 != 0 && columns % 2 != 0)
                --columns; //trim the last column.
            int size = rows * columns;
            //byte[] pixelData = MemoryManager.Allocate<byte>(size);
            byte[] pixelData = new byte[size];
            int i = 0;
            for (int row = 0; row < rows; ++row)
            {
                for (int column = 0; column < columns; column++)
                {
                    pixelData[i++] = image.GetPixel(column, row).R;
                }
            }
            return pixelData;
        }
        private static byte[] GetColorPixelData(Bitmap image, out int rows, out int columns)
        {
            rows = image.Height;
            columns = image.Width;
            //At least one of rows or columns must be even.
            if (rows % 2 != 0 && columns % 2 != 0)
                --columns; //trim the last column.
            BitmapData data = image.LockBits(new Rectangle(0, 0, columns, rows), ImageLockMode.ReadOnly, image.PixelFormat);
            IntPtr bmpData = data.Scan0;
            try
            {
                int stride = columns * 3;
                int size = rows * stride;
                //byte[] pixelData = MemoryManager.Allocate<byte>(size);
                byte[] pixelData = new byte[size];
                for (int i = 0; i < rows; ++i)
                    Marshal.Copy(new IntPtr(bmpData.ToInt64() + i * data.Stride), pixelData, i * stride, stride);
                //swap BGR to RGB
                SwapRedBlue(pixelData);
                return pixelData;
            }
            finally
            {
                image.UnlockBits(data);
            }
        }
