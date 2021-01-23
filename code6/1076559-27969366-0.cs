    Public Sub Test()
        Assert.Throws(Of Exception)(AddressOf DoSomethingPassingTwo)
    End Sub
    
    Public Sub DoSomethingPassingTwo()
        DoSomething(2)
    End Sub
    
    Public Sub DoSomething(i As Integer)
        Throw New Exception()
    End Sub
