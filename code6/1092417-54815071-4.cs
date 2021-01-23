    'Note this class in C# will (and MUST) be Sealed, which is the equivalent in VB of NotInheritable with Shared Members
    Public NotInheritable Class ProtectMyDLL 
    
        Private Shared ReadOnly MyPublicKey As String = "<RSAKeyValue><Modulus>SomeLongBase64StringHere</Modulus><Exponent>SomeShortBase64StringHere</Exponent></RSAKeyValue>"
        Private Shared _DataToSign(32) As Byte 'Recommended size in Bytes, for SHA256 hash signature (256 bits = 32 bytes)
        Public Shared Property SignedData As Byte() 'The caller will be asked to put the signed version of DataToSign here
    
        Public Shared ReadOnly Property DataToSign As Byte()
            Get
                If _DataToSign Is Nothing Then 'If empty then generate a new random string (string size is determined by the size of the Byte() array: 32)
                    Using MyRndGen = System.Security.Cryptography.RandomNumberGenerator.Create
                        MyRndGen.GetBytes(_DataToSign)
                    End Using
                End If
                Return _DataToSign
            End Get
        End Property
    
    
        Public Shared Function UserIsGenuine() As Boolean
            Using MyRSA As New System.Security.Cryptography.RSACryptoServiceProvider
                MyRSA.FromXmlString(MyPublicKey)
                UserIsGenuine = MyRSA.VerifyData(DataToSign,
                                                 System.Security.Cryptography.CryptoConfig.MapNameToOID("SHA256"),
                                                 SignedData)
                _DataToSign = Nothing 'This forces the data to be signed to change each time an access to the DLL is granted; otherwise the data to be signed will change only each time the Application is started. Argueably necessary, argueably consumming unnecessary resources..
            End Using
    
        End Function
    
    End Class
    Public Class MySecretClass
        Public Shared Sub IntelectualPropertyMethod()
            If Not ProtectMyDLL.UserIsGenuine() Then
                Throw New System.AccessViolationException("Caller signature could not be verified.")
                Exit Sub
            End If
            '... This code is protected
        End Sub
    End Class
