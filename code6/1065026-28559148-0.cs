    Imports System.Text
      Public Class frm
    Private Barcode As StringBuilder
    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.TBX_Scan.Focus()
        Barcode = New StringBuilder()
    End Sub
    Private Sub frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Barcode.Append(e.KeyChar)
    End Sub 
