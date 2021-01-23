    Imports System.ComponentModel.DataAnnotations
    
    Public Class LoginViewModel
        <Required>
        <Display(Name:="Nombre de usuario")>
        Public Property UserName As String
    
        <Required>
        <DataType(DataType.Password)>
        <Display(Name:="Contraseña")>
        Public Property Password As String
    
        <Display(Name:="¿Recordar cuenta?")>
        Public Property RememberMe As Boolean
    
        Public ReadOnly Property UsuarioValido As Boolean
            Get
                Return Password = "secreto" 'Password Here!
            End Get
        End Property
    
    End Class
