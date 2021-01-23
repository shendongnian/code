    using System.Windows.Forms;
    ...
    if(SystemInformation.TerminalServerSession)
    {
      // do stuff where the user is using remote desktop
    }
    else
    {
      // user is connected locally, e.g. the console
    }
