    public class PerWebRequestLifestyleModule : IHttpModule
    {
        ...
        private static void EnsureInitialized()
    		{
    			if (initialized)
    			{
    				return;
    			}
    			var message = new StringBuilder();
    			message.AppendLine("Looks like you forgot to register the http module " + typeof(PerWebRequestLifestyleModule).FullName);
    			message.AppendLine("To fix this add");
    			message.AppendLine("<add name=\"PerRequestLifestyle\" type=\"Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule, Castle.Windsor\" />");
    			message.AppendLine("to the <httpModules> section on your web.config.");
    			if (HttpRuntime.UsingIntegratedPipeline)
    			{
    				message.AppendLine(
    					"Windsor also detected you're running IIS in Integrated Pipeline mode. This means that you also need to add the module to the <modules> section under <system.webServer>.");
    			}
    			else
    			{
    				message.AppendLine(
    					"If you plan running on IIS in Integrated Pipeline mode, you also need to add the module to the <modules> section under <system.webServer>.");
    			}
    #if !DOTNET35
    			message.AppendLine("Alternatively make sure you have " + PerWebRequestLifestyleModuleRegistration.MicrosoftWebInfrastructureDll +
    			                   " assembly in your GAC (it is installed by ASP.NET MVC3 or WebMatrix) and Windsor will be able to register the module automatically without having to add anything to the config file.");
    #endif
    			throw new ComponentResolutionException(message.ToString());
    		}
        ...
    }
