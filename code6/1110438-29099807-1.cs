        private Result ScanBitmap(WriteableBitmap writeableBmp)
        {
            var barcodeReader = new BarcodeReader
            {
                Options = new ZXing.Common.DecodingOptions()
                {
                    TryHarder = true
                },
                AutoRotate = true
            };
            var result = barcodeReader.Decode(writeableBmp);
            if (result != null)
            {
                CaptureImage.Source = writeableBmp;
            }
            return result;
        }
