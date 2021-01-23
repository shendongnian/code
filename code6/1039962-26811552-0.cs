    namespace MyLayoutRenderers
    {
        using System.ComponentModel;
        using System.Globalization;
        using System.Text;
    
        using NLog.Config;
    
        [LayoutRenderer("persianlongdate")]
        [ThreadAgnostic]
        public class PersianSLongDateLayoutRenderer : LayoutRenderer
        {
            PersianCalendar pc = new PersianCalendar();
            /// <summary>
            /// Gets or sets a value indicating whether to output UTC time instead of local time.
            /// </summary>
            /// <docgen category='Rendering Options' order='10' />
            [DefaultValue(false)]
            public bool UniversalTime { get; set; }
    
            /// <summary>
            /// Renders the current short date string (yyyy-MM-dd) and appends it to the specified <see cref="StringBuilder" />.
            /// </summary>
            /// <param name="builder">The <see cref="StringBuilder"/> to append the rendered data to.</param>
            /// <param name="logEvent">Logging event.</param>
            protected override void Append(StringBuilder builder, LogEventInfo logEvent)
            {
                DateTime ts = logEvent.TimeStamp;
                //Not sure if UniversalTime makes sense for PersianCalendar.  Do you?
                if (this.UniversalTime)
                {
                    ts = ts.ToUniversalTime();
                }
                builder.Append(String.Format("{0}-{1}-{2}-{3}:{4}-{5}-{6}",
                    pc.GetDayOfWeek(ts),
                    pc.GetMonth(ts),
                    pc.GetDayOfMonth(ts),
                    pc.GetYear(ts),
                    pc.GetHour(ts), 
                    pc.GetMinute(ts),
                    pc.GetSecond(ts));
            }
        }
    }
