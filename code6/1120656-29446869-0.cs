    // using SharpSvn;
    bool foundModification = false;
    using(SvnClient client = new SvnClient()
    {
       client.Status(@"C:\my\working\copy",
                     delegate(object sender, SvnStatusEventArgs e)
                     {
                        foundModification = true;
                        e.Cancel = true;
                     });
    }
