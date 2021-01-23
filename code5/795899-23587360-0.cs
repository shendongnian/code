            ' Use same winword instance if there; if not, create new one
        Dim oApp As Application
        Try
            oApp = DirectCast(Runtime.InteropServices.Marshal.GetActiveObject("Word.Application"), Application)
        Catch ex As Exception
            ' Word not yet open; open new instance
            Try
                ' Ensure we have Word installed
                oApp = New Application()
            Catch eApp As Exception
                Throw New ApplicationException(String.Format("You must have Microsoft Word installed to run the Top Line report"))
            End Try
        End Try
        oApp.Visible = True
