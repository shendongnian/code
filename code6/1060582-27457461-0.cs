    Imports System.ComponentModel
    Imports System.Runtime.CompilerServices
    Public Module Extensions
        <Extension()>
        Public Function [Property](Of TSource)(source As IEnumerable(Of TSource), name As String) As IEnumerable(Of Object)
            Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(GetType(TSource)).Find(name, True)
            Return source.Select(Function(item As TSource) descriptor.GetValue(item))
        End Function
        <Extension()>
        Public Function [Property](Of TSource, TResult)(source As IEnumerable(Of TSource), name As String) As IEnumerable(Of TResult)
            Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(GetType(TSource)).Find(name, True)
            Return source.Select(Function(item As TSource) CType(descriptor.GetValue(item), TResult))
        End Function
    End Module
