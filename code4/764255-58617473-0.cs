      Private Sub btnprintbarcodes_Click(sender As Object, e As EventArgs) Handles btnprintbarcodes.Click
    
            PrintDocument1.Print()
        End Sub
    
       Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
            e.PageSettings.PrinterSettings.PrinterName = ApplicationHelper.GetApplicationSettingValue("Barcode_Printer_Name")
            Dim barcodeImageFile As String = String.Empty
            If UltraCode128Barcode1.Data IsNot Nothing Then
                barcodeImageFile = String.Concat(Path.GetTempPath(), Guid.NewGuid(), ".tiff")
                UltraCode128Barcode1.SaveTo(barcodeImageFile, ImageFormat.Tiff)
                Dim barcodeimage = Image.FromFile(barcodeImageFile)
                e.Graphics.DrawImage(barcodeimage, 0, 0)
                e.Graphics.DrawString(UltraCode128Barcode1.Data, New Font("arial", 8), New SolidBrush(Color.Black), 0, 50)
            End If
            If (File.Exists(barcodeImageFile)) Then
                'File.Delete(barcodeImageFile)
            End If
        End Sub
    
      Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
            ApplicationHelper.ShowGeneralDialog("The Program is about to print barcode(s).Make sure your barcode printer is on and loaded")
        End Sub
