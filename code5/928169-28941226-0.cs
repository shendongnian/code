    public static void ConvertHtmlToPdf(string htmlHeader, string htmlContent, string htmlFooter, PdfOutput output)
    {
        String inputHeaderFilePath;
        String inputContentFilePath;
        String inputFooterFilePath;
        inputHeaderFilePath = Path.Combine(Environment.TempFolderPath, String.Format("{0}.html", Guid.NewGuid()));
        inputContentFilePath = Path.Combine(Environment.TempFolderPath, String.Format("{0}.html", Guid.NewGuid()));
        inputFooterFilePath = Path.Combine(Environment.TempFolderPath, String.Format("{0}.html", Guid.NewGuid()));
        // Feed Temp files
        File.WriteAllText(inputHeaderFilePath, htmlHeader);
        File.WriteAllText(inputContentFilePath, htmlContent);
        File.WriteAllText(inputFooterFilePath, htmlFooter);
        PdfDocument document = new PdfDocument() { HeaderUrl = inputHeaderFilePath, Url = inputContentFilePath, FooterUrl = inputFooterFilePath };
        ConvertHtmlToPdf(document, output);
        //Remove Temp files
        File.Delete(inputHeaderFilePath);
        File.Delete(inputContentFilePath);
        File.Delete(inputFooterFilePath);
    }
