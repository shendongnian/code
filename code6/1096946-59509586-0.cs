    Dim stName As String = ""
    Public Property SetGetName() As String
        Set(value As String)
            If value = "A" Then
                value += " Letter is "
            End If
            stName = value
        End Set
        Get
            If stName <> "" Then
                Return stName
            End If
            Return "Empty"
        End Get
    End Property
    Public WriteOnly Property SetName As String
        Set(value As String)
            If value = "A" Then
                value += " Letter is "
            End If
            stName = value
        End Set
    End Property
    Public ReadOnly Property GetName As String
        Get
            If stName <> "" Then
                Return stName
            End If
            Return "Empty"
        End Get
    End Property
  
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SetName = "AAA" ' here we set value 
        MsgBox(GetName) ' here we get value
        'or 
        SetGetName = "AAA"
        MsgBox(SetGetName)
    End Sub
