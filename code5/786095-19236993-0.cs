    //viewmodel.File is HttpPostedFileBase
    viewModel.File.InputStream.Position = 0; //<-----This fixed it!
    byte[] fileData;
    using (var binaryReader = new BinaryReader(viewModel.File.InputStream))
    {
        fileData = binaryReader.ReadBytes(viewModel.File.ContentLength);
    }
