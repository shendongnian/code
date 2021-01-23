    Public Sub createNewLineSubCategory( ByRef newSubCatName As String, ByRef newSubCatColor As Autodesk.Revit.DB.Color)
      Dim lineCat As Autodesk.Revit.DB.Category
      Dim lineSubCat As Autodesk.Revit.DB.Category
    
      Dim docTransaction As New Autodesk.Revit.DB.Transaction(ptr2Doc)
 
      lineCat = ptr2Doc.Settings.Categories.Item(BuiltInCategory.OST_Lines)
 
      Try
        docTransaction.SetName("hatch22 - Create SubCategory")
        docTransaction.Start()
        lineSubCat = ptr2Doc.Settings.Categories.NewSubcategory(lineCat, newSubCatName)
        lineSubCat.LineColor = newSubCatColor
        docTransaction.Commit()
 
      Catch ex As Exception
        MsgBox(ex.ToString)
      End Try
 
    End Sub
