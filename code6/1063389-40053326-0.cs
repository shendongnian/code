	Private Property WPFApplication As Windows.Application
	Public Sub New()
		' This call is required by the Windows Form Designer.
		InitializeComponent()
		' Add any initialization after the InitializeComponent() call.
		If (WPFApplication Is Nothing) Then
			WPFApplication = New Windows.Application
			WPFApplication.ShutdownMode = Windows.ShutdownMode.OnExplicitShutdown
		End If
	End Sub
	
	Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If (WPFApplication IsNot Nothing) Then
			WPFApplication.Shutdown()
		End If
	End Sub
