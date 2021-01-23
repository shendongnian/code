    Private Sub ExcelRangeAddComboBox()
    
        Dim ComboBox1 As Microsoft.Office.Tools.Excel. _
            Controls.ComboBox = Me.Controls.AddComboBox( _
            Me.Range("A1", "B1"), "ComboBox1")
        ComboBox1.Items.Add("First Item")
        ComboBox1.Items.Add("Second Item")
        ComboBox1.SelectedIndex = 0
    
    End Sub
