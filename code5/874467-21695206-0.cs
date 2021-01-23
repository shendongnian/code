    Private Sub btnPrint_Click(sender As Object, e As RoutedEventArgs) Handles btnPrint.Click
        Dim printDialog = New System.Windows.Controls.PrintDialog()
        If printDialog.ShowDialog = False Then
            Return
        End If
        Dim fixedDocument = New FixedDocument()
        fixedDocument.DocumentPaginator.PageSize = New System.Windows.Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight)
        For Each p In _lablefilenames
            Dim page As New FixedPage()
            Dim info As System.IO.FileInfo = New FileInfo(p)
            'If info.Extension.ToLower = ".gif" Then
            '    page.Width = fixedDocument.DocumentPaginator.PageSize.Height
            '    page.Height = fixedDocument.DocumentPaginator.PageSize.Width
            'Else
            page.Width = fixedDocument.DocumentPaginator.PageSize.Width
            page.Height = fixedDocument.DocumentPaginator.PageSize.Height
            'End If
            Dim img As New System.Windows.Controls.Image()
            ' PrintIt my project's name, Img folder
            'Dim uriImageSource = New Uri(p, UriKind.RelativeOrAbsolute)
            'img.Source = New BitmapImage(uriImageSource)
            Dim Bimage As New BitmapImage()
            Bimage.BeginInit()
            Bimage.CacheOption = BitmapCacheOption.OnLoad
            Bimage.UriSource = New Uri(p)
            If info.Extension.ToLower = ".gif" Then Bimage.Rotation += Rotation.Rotate90
            Bimage.EndInit()
            'img.Width = 100
            'img.Height = 100
            img.Source = Bimage
            page.Children.Add(img)
            Dim pageContent As New PageContent()
            DirectCast(pageContent, IAddChild).AddChild(page)
            fixedDocument.Pages.Add(pageContent)
        Next
        ' Print me an image please!
        printDialog.PrintDocument(fixedDocument.DocumentPaginator, "Print")
    End Sub
