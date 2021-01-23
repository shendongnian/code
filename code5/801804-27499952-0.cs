    Private Shared Resources As Type = Reflection.Assembly.LoadFile(IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources.dll")).GetType("Resources.Reports")
    Default Public ReadOnly Property Item(name As String) As String
        Get
            Return Resources.GetProperty(name, Reflection.BindingFlags.Static Or Reflection.BindingFlags.Public).GetValue(Nothing).ToString()
        End Get
    End Property
