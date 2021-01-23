     public static void Create(string urltoconvert, string savepath)
            {
     this.BeginInvoke((System.Threading.ThreadStart)delegate()
                {
                var doc = new PdfDocument();
                var thread = new Thread(() => doc.LoadFromHTML(urltoconvert, false, true, true));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                doc.SaveToFile(savepath);
                doc.Close();
                System.Diagnostics.Process.Start(savepath);
    
     });
            }
