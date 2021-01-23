    char separator=',';
    int temp;
    var list1=firstTextBox.Split(new char[]{separator})
                          .Where(n=>int.TryParse(n,out temp))
                          .Select(n=>temp);
    var list2=secondTextBox.Split(new char[]{separator})
                          .Where(n=>int.TryParse(n,out temp))
                          .Select(n=>temp);
    var common=list1.Intersect(list2);
