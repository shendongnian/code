        Public Shared Function CancelPrintJob(printerName As String, printJobID As Integer) As Boolean
            Dim isActionPerformed As Boolean = False
            Dim searchQuery As String = "SELECT * FROM Win32_PrintJob"
            Dim searchPrintJobs As New ManagementObjectSearcher(searchQuery)
            Dim prntJobCollection As ManagementObjectCollection = searchPrintJobs.[Get]()
            For Each prntJob As ManagementObject In prntJobCollection
                Dim jobName As System.String = prntJob.Properties("Name").Value.ToString()
                Dim splitArr As Char() = New Char(0) {}
                splitArr(0) = Convert.ToChar(",")
                Dim prnterName As String = jobName.Split(splitArr)(0)
                Dim prntJobID As Integer = Convert.ToInt32(jobName.Split(splitArr)(1))
                Dim documentName As String = prntJob.Properties("Document").Value.ToString()
                If [String].Compare(prnterName, printerName, True) = 0 Then
                    If prntJobID = printJobID Then                 
                        prntJob.Delete()
                        isActionPerformed = True
                        Exit For
                    End If
                End If
            Next
            Return isActionPerformed
        End Function 
