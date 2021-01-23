    To access or use tesseract 3.02 trained data we have to create separate wrapper class like below.
    
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Drawing;
    
    /// <summary>
    /// Summary description for TesseractOCR
    /// </summary>
    /// 
    namespace tesseractThree
    {
        public class TesseractOCR
        {
            public TesseractOCR()
            {
                //
                // TODO: Add constructor logic here
                //
            }
    
            private string commandpath;
            private string outpath;
            private string tmppath;
    
    
            public TesseractOCR(string commandpath)
            {
                this.commandpath = commandpath;
                tmppath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\out.tif";
                outpath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\out.txt";
            }
    
            public string analyze(string filename,string lang,bool noLine)
            {
                string args = filename + " " + outpath.Replace(".txt", "");
                ProcessStartInfo startinfo;
                if (noLine == true)
                {
                    startinfo = new ProcessStartInfo(commandpath, args + " -l " + lang + " -psm 6");
                }
                else
                {
                    startinfo = new ProcessStartInfo(commandpath, args + " -l " + lang);
                }
                startinfo.CreateNoWindow = true;
                startinfo.UseShellExecute = false;
                Process.Start(startinfo).WaitForExit();
    
                string ret = "";
                using (StreamReader r = new StreamReader(outpath))
                {
                    string content = r.ReadToEnd();
                    ret = content;
                }
                File.Delete(outpath);
                return ret;
            }
    
            public string OCRFromBitmap(Bitmap bmp,string lang,bool noLine)
            {
               
                bmp.Save(tmppath, System.Drawing.Imaging.ImageFormat.Tiff);
                string ret = analyze(tmppath,lang,noLine);
                File.Delete(tmppath);
                return ret;
            }
          /*  public string OCRFromFile(string filename)
            {
                return analyze(filename);
            }*/
        }
    }
    
        //Usage of this class
                    string lang = "enc";
                    Bitmap b = new Bitmap(@"D:\Image\enc.test_font.exp0.tif");
                    TesseractOCR ocr = new TesseractOCR(@"C:\Program Files\Tesseract-OCR\tesseract.exe");
                    string result = ocr.OCRFromBitmap(b, lang,true);
                    Label1.Text = result;
    
    OR Refer below link for more details.
    https://gist.github.com/yatt/915443
