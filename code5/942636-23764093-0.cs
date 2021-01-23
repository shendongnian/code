    Private ReadOnly _controller As SController
    
    Public Sub New()
       Me.New(New SController())
    End Sub
    
    Public Sub New(controller As SController)
       Initialize(controller)
    End Sub
    Private Sub Initialize(controller As SController)
       InitializeComponent()
       _controller = controller
       controller.EnumerateDevices(deviceDropdown.Items)
       _thread = New Thread(AddressOf ReadLoop) With { _
          .IsBackground = True _
       }
    
       _thread.Start()
    End Sub
