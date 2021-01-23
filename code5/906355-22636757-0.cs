    Imports System.Management
    Imports System.Text.RegularExpressions
    
                Try
                    Dim scope As New ManagementScope("\\" + computername + "\root\CIMV2")
                    scope.Connect()
                    Dim query As New ObjectQuery( _
                        "SELECT * FROM Win32_NetworkAdapter WHERE Manufacturer != 'Microsoft' AND NOT PNPDeviceID LIKE 'ROOT\\%'")
                    Dim searcher As New ManagementObjectSearcher(scope, query)
                    For Each queryObj As ManagementObject In searcher.Get()
                        Dim ServiceName As String = queryObj("ServiceName")
                        Dim ProductName As String = queryObj("Description")
                        If Regex.IsMatch(ServiceName, ".*NETw.*") Then
                            'if we detect a wireless connection service name...
                            If Regex.IsMatch(queryObj("netenabled"), ".*true.*", RegexOptions.IgnoreCase) Then                                
                               MessageBox.Show(ProductName + " is already enabled! [ " + queryObj("netenabled") + " ]")
                                
                            Else
                                'Try to enable the wireless connection here
                                queryObj.InvokeMethod("Enable", Nothing)                                
                                    MessageBox.Show(ProductName + " was successfully enabled!")                               
                            End If
                        End If
                    Next
                Catch ex As Exception
                    Messagebox.show(ex.Message)
                End Try
