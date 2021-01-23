    string relativePath = System.IO.Directory.GetCurrentDirectory();
    int position = relativePath.IndexOf(@"\GameSystem");
    if (position > 0)
    {
        relativePath.Remove(position);
    }
    else
    {
        //handle condition rather than throw "start index cannot be less than zero"
    }
