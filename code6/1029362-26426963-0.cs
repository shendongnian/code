          static void Main(string[] args)
          {
            Console.WriteLine("starting");
                String filename = "d:\\tmp\\t1.pdf";
        
                if (File.Exists(filename)){
                    byte[] pdfFile = File.ReadAllBytes(filename);
                    PdfReader reader = new PdfReader(pdfFile);
                    int numberOfPages = pdfReader.NumberOfPages;
                    Console.WriteLine(numberOfPages);
                }
        
              }
       }
