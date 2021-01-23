    using System;
    using System.Globalization;
    using System.Text;
    using NLog.Config;
    namespace CustomLayoutRenderer
    {
        /// <summary>
        /// Log event context data.
        /// </summary>
        [LayoutRenderer("event-context-all")]
        public class EventContextLayoutRenderer : LayoutRenderer
        {
            /// <summary>
            /// Renders the specified log event context item and appends it to the specified <see cref="StringBuilder" />.
            /// </summary>
            /// <param name="builder">The <see cref="StringBuilder"/> to append the rendered data to.</param>
            /// <param name="logEvent">Logging event.</param>
            protected override void Append(StringBuilder builder, LogEventInfo logEvent)
            {
                foreach (var item in logEvent.Properties)
                {
                    builder.Append(Convert.ToString(logEvent.Properties[item], CultureInfo.InvariantCulture));
                }
    
            }
        }
    }
