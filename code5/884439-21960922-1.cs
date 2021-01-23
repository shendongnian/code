	Imports System.IO
	Imports System.Text
	Imports System.Security.Cryptography
	Public Class Crypto
		Private Shared _UserKey As String = ""
		Private Shared _SHA256 As New SHA256Managed
		Private Shared _AES As New RijndaelManaged
		Private Const _IV As String = "P5acZMXujMRdmYvFXYfncS7XhrsPNfHkerTnWVT6JcfcfHFDwa" ' <--- this can be anything you want
		Public Shared Property UserKey() As String
			Get
				Return Crypto._UserKey
			End Get
			Set(ByVal value As String)
				Crypto._UserKey = value
				Crypto._AES.KeySize = 256
				Crypto._AES.BlockSize = 256
				Crypto._AES.Key = Crypto.SHA256Hash(Crypto._UserKey)
				Crypto._AES.IV = Crypto.SHA256Hash(Crypto._IV)
				Crypto._AES.Mode = CipherMode.CBC
			End Set
		End Property
		Public Shared Function SHA256Hash(ByVal value As String) As Byte()
			Return Crypto._SHA256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
		End Function
		Public Shared ReadOnly Property AES() As RijndaelManaged
			Get
				Return Crypto._AES
			End Get
		End Property
	End Class
