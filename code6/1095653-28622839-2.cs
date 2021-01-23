    var formBehaviorFieldInfo = Articles_Search
      .GetType()
      .GetField("FormBehavior", BindingFlags.NonPublic | BindingFlags.Instance);
    var formBehavior = formBehaviorFieldInfo.GetValue(Articles_Search);
    var itemPropertyInfo = formBehavior.GetType().GetProperty("Item");
    itemPropertyInfo.SetValue(formBehavior, "Control", new[] { "Value" });
    var hiddenColumnsFieldInfo = Articles_Search
      .GetType()
      .GetField("HiddenColumns", BindingFlags.NonPublic | BindingFlags.Instance);
    var hiddenColumns = hiddenColumnsFieldInfo.GetValue(Articles_Search);
    var addMethodInfo = hiddenColumns.GetType().GetMethod("Add");
    addMethodInfo.Invoke(hiddenColumns, new[] { "article_cost" });
