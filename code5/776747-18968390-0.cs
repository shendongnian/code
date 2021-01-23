        /// <summary>
        /// A site collection is being deleted
        /// </summary>
        public override void SiteDeleting(SPWebEventProperties properties)
        {
            base.SiteDeleting(properties);
			if(/*some condition*/)
			{ 
				properties.Cancel = true;
				properties.ErrorMessage = "This site collection should never be deleted.";
			}
		 }
