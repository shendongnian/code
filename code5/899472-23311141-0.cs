    public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
    {
        var originalFileName = GetOriginalFileName(wszInputFilePath);
        SaveOutputContent(rgbOutputFileContents, out pcbOutput, system.IO.File.ReadAllText(originalFileName));
        return VSConstants.S_OK;
    }
