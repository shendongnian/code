        using System;
        using System.Linq;
        using System.IO;
        using System.IO.IsolatedStorage;
        using System.Collections.Generic;
        using Microsoft.LightSwitch;
        using Microsoft.LightSwitch.Framework.Client;
        using Microsoft.LightSwitch.Presentation;
        using Microsoft.LightSwitch.Presentation.Extensions;
        namespace LightSwitchApplication
        {
            public partial class |ScreenName|
            {
                partial void |ScreenName|_Activated()
                {
                    // Write your code here.
                    if (Application.Current.User.HasPermission(Permissions.|CantReadLookupRole|))
                    {
                        this.FindControl("LookupItem1").IsEnabled = false;
                    }
                    
                }
            }
        }
