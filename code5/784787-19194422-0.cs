    Interface IImpliedReadOnly
    Integer SomeNumber 
    {
	get
    }
    End Interface
    Class Implementation
  	 Implements IImpliedReadOnly
    Private someNumber As Integer =  0 
    Public Property SomeNumber() As Integer
	Get 
	Return someNumber
	End Get
	Set (ByVal Value As Integer) 
	someNumber=value
	End Set
        End Property
        {
        	get
               {
	          Return someNumber
               }
              set
             {
        	someNumber=value
             }
             End Class
              {
              Private someNumber As Integer =  0 
        Public Property SomeNumber() As Integer
	Get 
	Return someNumber
	End Get
	Set (ByVal Value As Integer) 
	someNumber=value
	End Set
    End Property
