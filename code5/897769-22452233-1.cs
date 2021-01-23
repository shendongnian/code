using System;
using System.IO;
using System.IO.Packaging;
using System.Text;
static class PdfExtractor
{
    public static void ExtractPdf(string packagePath, string destinationDirectory)
    {
        using (var package = Package.Open(packagePath))
        {
            int i = 1;
            foreach (var part in package.GetParts())
                if (part.ContentType == &quot;application/vnd.openxmlformats-officedocument.oleObject&quot;)
                {
                    // PDF data is embedded into OLE Object package part.
                    var pdfContent = GetPdfContent(part.GetStream());
                    if (pdfContent != null)
                        File.WriteAllBytes(Path.Combine(destinationDirectory, &quot;EmbeddedPdf&quot; + (i++) + &quot;.pdf&quot;), pdfContent);
                }
        }
    }
    private static byte[] GetPdfContent(Stream stream)
    {
        // Every PDF file/data starts with &apos;%PDF&apos; and ends with &apos;%%EOF&apos;.
        const string pdfStart = &quot;%PDF&quot;, pdfEnd = &quot;%%EOF&quot;;
        byte[] bytes = ConvertStreamToArray(stream);
        string text = Encoding.ASCII.GetString(bytes);
        int startIndex = text.IndexOf(pdfStart, StringComparison.Ordinal);
        if (startIndex &lt; 0)
            return null;
        int endIndex = text.LastIndexOf(pdfEnd, StringComparison.Ordinal);
        if (endIndex &lt; 0)
            return null;
        var pdfBytes = new byte[endIndex + pdfEnd.Length - startIndex];
        Array.Copy(bytes, startIndex, pdfBytes, 0, pdfBytes.Length);
        return pdfBytes;
    }
    private static byte[] ConvertStreamToArray(Stream stream)
    {
        var buffer = new byte[16 * 1024];
        using (var ms = new MemoryStream())
        {
            int read;
            while ((read = stream.Read(buffer, 0, buffer.Length)) &gt; 0)
                ms.Write(buffer, 0, read);
            return ms.ToArray();
        }
    }
}
