    Public Partial Class Form1
	Inherits Form
	Private radGridView1 As RadGridView
	Public Sub New()
		InitializeComponent()
		radGridView1 = New RadGridView()
		Me.Controls.Add(radGridView1)
		radGridView1.Dock = DockStyle.Fill
		Dim textCol As New GridViewTextBoxColumn("Name")
		radGridView1.Columns.Add(textCol)
		Dim ageCol As New GridViewDecimalColumn("Age")
		radGridView1.Columns.Add(ageCol)
		Dim prgsCol As New ProgressBarColumn("Progress")
		radGridView1.Columns.Add(prgsCol)
		radGridView1.Rows.Add("Steve", 21, 15)
		radGridView1.Rows.Add("John", 43, 90)
		radGridView1.Rows.Add("Mike", 23, 66)
	End Sub
    End Class
