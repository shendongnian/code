        Dim objects = New List(Of TestObject)()
    objects.Add(New TestObject(1, "Test1"))
    objects.Add(New TestObject(1, "Test2"))
    objects.Add(New TestObject(1, "Test3"))
    objects.Add(New TestObject(2, "Test4"))
    objects.Add(New TestObject(2, "Test5"))
    objects.Add(New TestObject(2, "Test6"))
    
    
    Dim t As List(Of Integer) = objects.GetDistict(Of Integer, TestObject)("Zone")
    Public Class TestObject
    	Public Property Zone() As Integer
    		Get
    			Return m_Zone
    		End Get
    		Set
    			m_Zone = Value
    		End Set
    	End Property
    	Private m_Zone As Integer
    	Public Property Address() As String
    		Get
    			Return m_Address
    		End Get
    		Set
    			m_Address = Value
    		End Set
    	End Property
    	Private m_Address As String
    
    	Public Sub New(zone__1 As Integer, address__2 As String)
    		Zone = zone__1
    		Address = address__2
    	End Sub
    End Class
        Public NotInheritable Class DistinctExtension
    	Private Sub New()
    	End Sub
    	<System.Runtime.CompilerServices.Extension> _
    	Public Shared Function GetDistict(Of T, S)(source As List(Of S), name As String) As List(Of T)
    		Return source.[Select](Function(x) DirectCast(x.[GetType]().GetProperty(name).GetValue(x), T)).Distinct().ToList()
    	End Function
    
    End Class
