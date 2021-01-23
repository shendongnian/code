    Public Class ListBoxEx
        Inherits ListBox
    
        <Browsable(True), EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Property SelectedItemColor As ItemStateColors
    
        <Browsable(True), EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        DefaultValue(-1)>
        Public Property UnSelectedItemColor As ItemStateColors
        Public Sub New()
            ' they are Objects, be sure to instance them!
            ' VERY important!
            SelectedItemColor = New ItemStateColors
            UnSelectedItemColor = New ItemStateColors
    
        End Sub
    end class
