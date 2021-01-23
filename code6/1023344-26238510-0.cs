    public static void WriteEventViewerHistoryByTypes(IList<EventViewerCriticalityLevel> levelTypes, string logType, string filePath, IList<string> sources, DateTime? startDate = new System.Nullable<DateTime>(), DateTime? endDate = new System.Nullable<DateTime>())
		{
			if (levelTypes == null || levelTypes.Count == 0)
				levelTypes = new List<EventViewerCriticalityLevel> { EventViewerCriticalityLevel.Comment, EventViewerCriticalityLevel.Error, EventViewerCriticalityLevel.Fatal, EventViewerCriticalityLevel.Info, EventViewerCriticalityLevel.Warning };
			
			StringBuilder sb = new StringBuilder();
			sb.Append("<QueryList>");
			sb.AppendFormat("<Query Id=\"0\" Path=\"{0}\">", logType);
			sb.AppendFormat("	<Select Path=\"{0}\">", logType);
			sb.AppendFormat("   *[System[(");
			sb.AppendFormat("({0})", string.Join(" or ", levelTypes.Select(lev =>
			   {
				   
				   if (lev == EventViewerCriticalityLevel.Info)
					   return string.Format("Level={0} or Level=0", (int)lev);
				   else
					   return string.Format("Level={0}", (int)lev);
			   })));
			if (sources != null && sources.Count > 0)
			{
				sb.AppendFormat(" or ");
				sb.AppendFormat("(Provider[{0}])", string.Join(" or ", sources.Select(el => "@Name='" + el + "'")));
			}
			sb.AppendFormat(")");
			if (startDate.HasValue)
			{
				sb.AppendFormat(" and TimeCreated[@SystemTime >= '{0}']", startDate.Value.ToString("o"));
			}
			if (endDate.HasValue)
			{
				sb.AppendFormat(" and TimeCreated[@SystemTime <= '{0}']", endDate.Value.ToString("o"));
			}
			sb.AppendFormat("]]");
			sb.AppendFormat("	</Select>");
			sb.AppendFormat("</Query>");
			sb.Append("</QueryList>");
			try
			{
				EventLogSession sess = new EventLogSession();
				sess.ExportLogAndMessages(logType, PathType.LogName, sb.ToString(), filePath, true, CultureInfo.CurrentCulture);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
