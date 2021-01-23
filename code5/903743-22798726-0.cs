    var openDialog = new OpenFileDialog();
    openDialog.DefaultExt = "pdf";
    if (openDialog.ShowDialog() == true)
    {
        using (var input = openDialog.OpenFile())
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "pdf";
            if (saveDialog.ShowDialog() == true)
            {
                using (var reader = new PdfReader(input)) 
                {
                    using (var output = saveDialog.OpenFile())
                    {
                        PdfEncryptor.Encrypt(
                            reader, output,
                            PdfWriter.ENCRYPTION_AES_256,
                            "password", "password",
                            PdfWriter.ALLOW_PRINTING);
                    }
                }
            }
        }
    }
