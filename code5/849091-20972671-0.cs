    var textPath = "somefile.txt";
    var pdfPath = "somefile.pdf";
    
    try {
      using (var scope = new TransactionScope()) {
        var textFileSave = new TextFileSave(textPath);
        var pdfFileSave = new PDFFileSave(pdfPath);
        Transaction.Current.TransactionCompleted += (sender, eventArgs) => {
          try {
            var sendEmail = new SendEmail();
            sendEmail.Send();
          }
          catch (Exception ex) {
            // Console.WriteLine(ex);
            textFileSave.CleanUp();
            pdfFileSave.CleanUp();
          }
        };
      
        Transaction.Current.EnlistVolatile(textFileSave, EnlistmentOptions.None);
        Transaction.Current.EnlistVolatile(pdfFileSave, EnlistmentOptions.None);
      
        scope.Complete();
      }
    }
    catch (Exception ex) {
      // Console.WriteLine(ex);
    }
    catch {
      // Console.WriteLine("Cannot complete transaction");
    }
