    private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
            {
                if (Debugger.IsAttached)
                {
                    // An unhandled exception has occurred; break into the debugger
                    FlurryWP8SDK.Api.LogError("Application_UnhandledException", e.ExceptionObject);
                    Debugger.Break();
                }
            }
