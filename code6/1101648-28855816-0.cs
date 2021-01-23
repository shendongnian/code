    TaskDialog td = new TaskDialog("Decision");
    td.MainContent = "What do you want to do?";
    td.AddCommandLink(TaskDialogCommandLinkId.CommandLink1,
                       "Use Simple Insertion Point",
                       "This option works for free-floating items");
    td.AddCommandLink(TaskDialogCommandLinkId.CommandLink2,
                        "Use Face Reference",
                        "Use this option to place the family on a wall or other surface");
    switch (td.Show())
     {
         case TaskDialogResult.CommandLink1:
            // do the simple stuff
            break;
         case TaskDialogResult.CommandLink2:
           // do the face reference
            break;
         default:
           // handle any other case.
            break;
     }
