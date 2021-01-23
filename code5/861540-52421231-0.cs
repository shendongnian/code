    public static string ImageToBase64(string _imagePath)
        {
            string _base64String = null;
        
            using (System.Drawing.Image _image = System.Drawing.Image.FromFile(_imagePath))
            {
                using (MemoryStream _mStream = new MemoryStream())
                {
                    _image.Save(_mStream, _image.RawFormat);
                    byte[] _imageBytes = _mStream.ToArray();
                    _base64String = Convert.ToBase64String(_imageBytes);
        
                    return "data:image/jpg;base64," + _base64String;
                }
            }
        }
