    Sub Main
        
        Dim c1 = New Container(Of String, String)()
        c1.Property1 = AddressOf Method1
        c1.Property2 = AddressOf Method1
        Method3(c1)
        Dim c2 = New Container(Of String, Integer)()
        c2.Property1 = AddressOf Method1
        c2.Property2 = AddressOf Method2
        Method3(c2)
    End Sub
    Public Sub Method1(x As String)
        Console.WriteLine("Method1: {0}", x)
    End Sub
    Public Sub Method2(x As Integer)
        Console.WriteLine("Method2: {0}", x)
    End Sub
    Public Sub Method3(Of T1, T2)(container as Container(Of T1, T2))
        Console.WriteLine("Method3 got {0}, {1}", GetType(T1), GetType(T2))
        ' Not sure how you would actually call the delegates
        If GetType(T1) = GetType(String) Then
            container.Property1.DynamicInvoke("Hello")
        ElseIf GetType(T1) = GetType(Integer) Then
            container.Property1.DynamicInvoke(123)
        End If
        If GetType(T2) = GetType(String) Then
            container.Property2.DynamicInvoke("World")
        ElseIf GetType(T2) = GetType(Integer) Then
            container.Property2.DynamicInvoke(456)
        End If
    End Sub
    Public Class Container(Of T1, T2)
        Public Property Property1 As Action(Of T1)
        Public Property Property2 As Action(Of T2)
    End Class
