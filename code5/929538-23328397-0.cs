    class Program
    {
        static void Main(string[] args)
        {
            StrokeScribeClass ss = new StrokeScribeClass();
    
            ss.Alphabet = enumAlphabet.DATAMATRIX;
            ss.DataMatrixMinSize = 16;
            ss.ECI = 0;
            ss.UTF8 = false;
    
            Console.Write("Input : ");
            string txt;
            txt = Console.ReadLine();
    
            ss.Text = txt;
            int w = ss.BitmapW;
            int h = ss.BitmapH;
            ss.SavePicture(txt + ".bmp", enumFormats.BMP, w * 2, h * 2);
            System.Console.Write(ss.ErrorDescription);
            WriteTextFile.Second(txt);
        }
    }
    
    
    class WriteTextFile
    {
        static void Second(string fileText)
        {
            System.IO.File
              .WriteAllText(@"C:\Users\Chad\Desktop\studio07\rinhoceros\20140428\WriteText.txt", fileText);
        }
    }
