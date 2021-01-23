    Public Class PreferredConstructorAttribute : Inherits Attribute
        Public Sub New()
        End Sub
    End Class
    
    Public Class tblFiltresChamps
        Public Sub New() ' Le JsonToObject a besoin d'un constructeur sans paramètres
            items = New BindingList(Of tblFiltreChamps)()
        End Sub
        <PreferredConstructor>
        Public Sub New(Env As SqiD23.Env)
            Me.New()
            _Env = Env
        End Sub
    End Class
