        /// <summary>
        /// Begins the application request.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            log4net.LogicalContext.Properties["FileID"] = <some id>;
            // Configure log4net. Log4net will load settings and create a new 
            //   file if it does not exist yet.
            log4net.Config.XmlConfigurator.Configure();
            log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logger.Debug(<some id>);
        }
