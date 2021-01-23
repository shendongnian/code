        /// <summary>
        /// Gets or sets a value indicating whether the browser will be opened in incognito mode.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if IE instance needs to be opened in incognito mode, otherwise <c>false</c>.
        /// </value>
        public static bool OpenInIncognitoMode
        {
            get { return Instance.OpenInIncognitoMode; }
            set { Instance.OpenInIncognitoMode = value; }
        }
