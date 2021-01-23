    Type myType = Type.GetType(LstBoxClass.SelectedItem.ToString());
    Type listtype = typeof(ResultSaver.ResultList<>).MakeGenericType(myType);
    object resultlist = Activator.CreateInstance(listtype);
    MethodInfo method = listtype.GetMethod("ReadListAsXmlAs");
    method.Invoke(resultlist, new Object[] {filenames.ToArray()});
