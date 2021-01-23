    Public Class CallerFromOutsideTheProtectedDLL
    
        Public Sub Main()
            ProtectMyDLL.SignedData = SignData(ProtectMyDLL.DataToSign) 'Must do this before every calls of a protected method, unless the _DataToSign = Nothing line is removed, in which case you onlyned to add this line once (see Secret DLL file).
            Call MySecretClass.IntelectualPropertyMethod()
        End Sub
    
        Private Function SignData(MyData As Byte()) As Byte()
            Return MyCrypto.SignWithMyPrivateKey(MyData) 'If you want to avoid having to provide a Private Key in an assembly, you can pass MyData through a WebAPI where the Private Key would be 100% securely kept secret. But then your App needs an access to the web, at least from times to times.
        End Function
    
    End Class
