	public static class NLogLinqPadExtensions
	{
		public static void ConfigureLogging()
		{
					var nlogConfig = @"
	<nlog>
		<targets>
		<target name='console' type='Console' layout='${date:format=dd/MM/yy HH\:mm\:ss\:fff} | ${level:uppercase=true} | ${message} | ${exception:format=tostring}' />
		</targets>
		<rules>
		<logger name='*' minlevel='Debug' writeTo='console' />
		</rules>
	</nlog>
			";
			
			using (var sr = new StringReader(nlogConfig))
			{
				using (var xr = XmlReader.Create(sr))
				{
					NLog.LogManager.Configuration = new XmlLoggingConfiguration(xr, null);
					NLog.LogManager.ReconfigExistingLoggers();
				}
			}
		}
	}
