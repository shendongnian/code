    <TypeConverter(GetType(ItemStateConverter))>
    Public Class ItemStateColors
    
        <Browsable(True), NotifyParentProperty(True),
        EditorBrowsable(EditorBrowsableState.Always), DefaultValue(GetType(Color), "")>
        Public Property EnabledBackColor As Color
    
        <Browsable(True), NotifyParentProperty(True),
        EditorBrowsable(EditorBrowsableState.Always), DefaultValue(GetType(Color), "")>
        Public Property DisabledBackColor As Color
    
        Public Sub New()
            ' default values, if any
            EnabledBackColor = SystemColors.Window
            DisabledBackColor = SystemColors.Control
        End Sub
    
    End Class
