    public List<FileItem> ExtractFacesFromImage(FileItem selectedFrame, string outputFolderPath,
        int minNeighbors, double scaleFactor, int widthIncrement = 80, int heightIncrement = 102)
    {
        lock (lockObj)
        {
            var currentFrame = new Image<Bgr, byte>(selectedFrame.Path);
            var gray = _currentFrame.Convert<Gray, Byte>();
            var result = new List<FileItem>();
            using (_face = new HaarCascade(_xmlFilePath))
            {
                if (gray != null)
                {
                    var facesDetected = gray.DetectHaarCascade(_face, scaleFactor, minNeighbors,Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_ROUGH_SEARCH,new Size(20, 20));
                    for (int index = 0; index < facesDetected[0].Length; index++)
                    {
                        var imgName = SaveExtractedFace(outputFolderPath, facesDetected, index, widthIncrement,
                                                        heightIncrement);
                        result.Add(new FileItem
                        {
                            IsSelected = true,
                            Path = imgName,
                            Name = Path.GetFileNameWithoutExtension(imgName)
                        });
                    }
              
                }
                return result;
            }
        }
    }
    private string SaveExtractedFace(string outputFolderPath, MCvAvgComp[][] facesDetected, int index, int widthIncrement, int heightIncrement)
    {
        var f = facesDetected[0][index];
        var cropRectangle = GetNewRectangle(f.rect, _currentFrame.Width, _currentFrame.Height, widthIncrement, heightIncrement);
        _tempImage = _currentFrame.Copy(cropRectangle);
        string imgName = outputFolderPath + "\\" + UniqueNameManager.Generate() + ".jpg";
        _tempImage.Save(imgName);
        DisposeObject(_tempImage);
        return imgName;
    }
