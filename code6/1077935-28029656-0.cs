	Imports System.ComponentModel
	Imports System.Runtime.CompilerServices
	Public Class Form1
		Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
			Task.Run(Sub()
						 Dim txt As String = TextBox1.InvokeGet(Function(tb) tb.Text)
						 Label1.InvokeSet(Sub(l) l.Text = "Hello " & txt)
					 End Sub)
		End Sub
	End Class
	Public Module Module1
		<Extension()> _
		Public Sub InvokeSet(Of T As ISynchronizeInvoke)(ByVal control As T, ByVal toPerform As Action(Of T))
			If control.InvokeRequired Then
				control.Invoke(toPerform, New Object() {control})
			Else
				toPerform(control)
			End If
		End Sub
		<Extension()> _
		Public Function InvokeGet(Of T As ISynchronizeInvoke)(ByVal control As T, ByVal toPerform As Func(Of T, Object))
			If control.InvokeRequired Then
				Return control.Invoke(toPerform, New Object() {control})
			Else
				Return toPerform(control)
			End If
		End Function
	End Module
