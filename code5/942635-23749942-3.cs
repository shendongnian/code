    ' simple constructor
    Public Sub New()
       Me.New(New SController())       ' calls overload below
    End Sub
    
    Public Sub New(controller As SController)
       InitializeComponent()           ' this is apparently a form????
       _controller = controller
       controller.EnumerateDevices(deviceDropdown.Items)
       _thread = New Thread(AddressOf ReadLoop) With { _
          .IsBackground = True }
    
       _thread.Start()
    End Sub
