    Implements IComparable
    Option Explicit
    Private Function IComparable_Compare(other As Variant) As Integer
        Dim comparable As MyClass
        If Not TypeOf other Is MyClass Then Err.Raise 5
        
        Set comparable = other
        If Me.SomeProperty < comparable.SomeProperty Then
            IComparable_Compare = -1
        ElseIf Me.SomeProperty > comparable.SomeProperty Then
            IComparable_Compare = 1
        End If
        
    End Function
    
    Private Function IComparable_Equals(other As Variant) As Boolean
        Dim comparable As MyClass
        If Not TypeOf other Is MyClass Then Err.Raise 5
        
        Set comparable = other
        IComparable_Equals = comparable.SomeProperty = Me.SomeProperty
        
    End Function
