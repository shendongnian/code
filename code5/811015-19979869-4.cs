    Imports Plutonix.UIDesigners
    Namespace Plutonix.UnDoMgr
    Public Class UndoManager
        Inherits Component      
        Implements ISupportInitialize      
        Private _TgtControls As New Collection(Of Control)
        <EditorAttribute(GetType(UnDoControlCollectionUIEditor), _
              GetType(System.Drawing.Design.UITypeEditor))> _
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Property UnDoTargets() As Collection(Of Control)
            Get
                Return _TgtControls
            End Get
            Set(ByVal value As Collection(Of Control))
                If value IsNot Nothing Then
                    _TgtControls = value
                Else
                    _TgtControls.Clear()
                End If
            End Set
        End Property
        '...
