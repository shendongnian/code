    public class SetSelectInfo : MonoBehaviour 
    {
         public string PDF;
         public void OpenPDFFile()
         {
             System.Diagnostics.Process.Start(Application.dataPath + "/PDFS/" + pdfFile);
         }
    }
