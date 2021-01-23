        Public Class Foos
    	 Implements ICollection(Of Foo)
    
    	 Private list As List(Of Foo)
    
    	 Public Sub New()
    		list = New List(Of Foo)()
    	 End Sub
    
    	 Public Default ReadOnly Property Item(index As Integer) As Foo
    		Get
    			Return list(index)
    		End Get
    	 End Property
       End Class
