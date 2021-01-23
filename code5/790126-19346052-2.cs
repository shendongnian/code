    var myList = new List<string> { "11", "22", "33" };
    var myString = "";
    var sb = new System.Text.StringBuilder();
    foreach (string s in myList)
    {
        sb.Append(s).Append(",");
    }
    myString = sb.Remove(sb.Length - 1, 1).ToString(); // Removes last ","
