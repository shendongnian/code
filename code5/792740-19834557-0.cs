    Public Class assignStudents
  
    Public Sub assignStudentsToGroups()
              Dim campList As New List(Of String)() From {"camp1", "camp2", "camp3"}
        Dim stuList As New List(Of stu)
        '  stuList  = select * stu's from database order by highest gpa first. pass in campusID
        Dim qtyComplex As Integer = 10
        Dim grpList As New List(Of grp)
        '  grpList = select * groups from db & qty of users in each grp.
        Dim qtyStudentsComplexGroup As Integer = qtyComplex * 5
        Dim count As Integer = 0
        '   for each campus
        For Each c As String In campList
            '   For each student in this campus
            For Each s As stu In stuList
                '   only loop round number of stu's that you want.
                '   i.e. the amount of complex projects * 5
                If count < qtyStudentsComplexGroup Then
                    '   These are clever kids, need to go in Type A. 
                    '   Loop through the list of all available groups
                    For Each g As grp In grpList
                        '   Check to see if that group is full (student count = 5)
                        If g.qty = 5 Then
                            '   it's full. Don't add them to this.
                        Else
                            '   it's not full, add student to this group.
                            '   add sql insert statement.
                            '   pass in student ID, grpID. GrpType A
                        End If
                    Next
                Else
                    For Each g As grp In grpList
                        '   Check to see if that group is full (student count = 5)
                        If g.qty = 5 Then
                            '   it's full. Don't add them to this.
                        Else
                            '   it's not full, add student to this group.
                            '   add sql insert statement.
                            '   pass in student ID, grpID. GrpType B
                        End If
                    Next
                End If
                '   increment the loop
                count += 1
            Next
        Next
    End Sub
    End Class
    Public Class stu
    Private _name As String = ""
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal Value As String)
            _name = Value
        End Set
    End Property
    Private _gpa As String = ""
    Public Property gpa() As Integer
        Get
            Return _gpa
        End Get
        Set(ByVal Value As Integer)
            _gpa = Value
        End Set
    End Property
    End Class
    Public Class grp
    Private _name As String = ""
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal Value As String)
            _name = Value
        End Set
    End Property
    Private _qty As Integer
    Public Property qty() As Integer
        Get
            Return _qty
        End Get
        Set(ByVal Value As Integer)
            _qty = Value
        End Set
    End Property
    End Class
