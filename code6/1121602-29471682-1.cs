    return new Container(
                x => x.Scan
                       (
                           scan =>
                           {
                               scan.Assembly("YourProject.UI");
                               scan.Assembly("YourProject.Infrastructure");
                               scan.Assembly("Your.Entities");
                               scan.WithDefaultConventions();
                               scan.LookForRegistries();
                           }
                       )
              );
