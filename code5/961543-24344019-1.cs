    UIApplication app = commandData.Application;
    UIDocument uidoc = app.ActiveUIDocument;
    Document ptr2Doc = uidoc.Document;
    Category lineCat = ptr2Doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
    Category lineSubCat;
    string newSubCatName = "NewLineStyle";
    Color newSubCatColor = new Color(255, 0, 0);  //Red
    try
    {
      using (Transaction docTransaction = new Transaction(ptr2Doc, "hatch22 - Create SubCategory"))
      {
        docTransaction.Start();
        lineSubCat = ptr2Doc.Settings.Categories.NewSubcategory(lineCat, newSubCatName);
        lineSubCat.LineColor = newSubCatColor;
        docTransaction.Commit();
      }
    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.ToString());
    }
