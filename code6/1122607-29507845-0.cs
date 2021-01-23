    using System.Diagnostics;
    using System.IO;
    ...
    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        var path = Path.GetFullPath(e.Uri.ToString());
        Process.Start(path);
    }
