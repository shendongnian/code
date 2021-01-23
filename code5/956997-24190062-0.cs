    Public Class MyCustomClassTypeDescriptor(Of TColl As Collection(Of TItem), TItem)
        Inherits ExpandableObjectConverter
        Public Overrides Function GetProperties(context As ITypeDescriptorContext, value As Object, attributes() As Attribute) As PropertyDescriptorCollection
            Dim coll = DirectCast(value, TColl)
            Dim props(coll.Count - 1) As PropertyDescriptor
            For i = 0 To coll.Count - 1
                props(i) = New MyCollectionPropertyDescriptor(Of TColl, TItem)("Item" & CStr(i))
            Next
            Return New PropertyDescriptorCollection(props)
        End Function
    End Class
    Public Class MyCollectionPropertyDescriptor(Of TColl, TItem)
        Inherits PropertyDescriptor
        Private _index As Integer = 0
        Public Sub New(name As String)
            MyBase.New(name, Nothing)
            Dim indexStr = Regex.Match(name, "\d+$").Value
            _index = CInt(indexStr)
        End Sub
        Public Overrides Function CanResetValue(component As Object) As Boolean
            Return False
        End Function
        Public Overrides ReadOnly Property ComponentType As Type
            Get
                Return GetType(TColl)
            End Get
        End Property
        Public Overrides Function GetValue(component As Object) As Object
            Dim coll = DirectCast(component, Collection(Of TItem))
            Return coll(_index)
        End Function
        Public Overrides ReadOnly Property IsReadOnly As Boolean
            Get
                Return True
            End Get
        End Property
        Public Overrides ReadOnly Property PropertyType As Type
            Get
                Return GetType(TItem)
            End Get
        End Property
        Public Overrides Sub ResetValue(component As Object)
        End Sub
        Public Overrides Sub SetValue(component As Object, value As Object)
        End Sub
        Public Overrides Function ShouldSerializeValue(component As Object) As Boolean
            Return False
        End Function
    End Class
