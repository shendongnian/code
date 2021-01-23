    var indices = new [] { 0, 1, 2, 4, 9 }; // whatever you want
    foreach (int i in indices)
    {
        sb.Append(string.Format("{0}!", lvI.SubItems[i].Text));
    }
