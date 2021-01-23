        /// <summary>
        /// Process RPL_WELCOME responses from the server.
        /// </summary>
        /// <param name="message">The message received from the server.</param>
        [MessageProcessor("001")]
        protected void ProcessMessageReplyWelcome(IrcMessage message)
        {
            Debug.Assert(message.Parameters[0] != null);
            Debug.Assert(message.Parameters[1] != null);
            this.WelcomeMessage = message.Parameters[1];
            // Extract nick name, user name, and host name from welcome message. Use fallback info if not present.
            var nickNameIdMatch = Regex.Match(this.WelcomeMessage.Split(' ').Last(), regexNickNameId);
            //this.localUser.NickName = nickNameIdMatch.Groups["nick"].GetValue() ?? this.localUser.NickName;
            this.localUser.UserName = nickNameIdMatch.Groups["user"].GetValue() ?? this.localUser.UserName;
            this.localUser.HostName = nickNameIdMatch.Groups["host"].GetValue() ?? this.localUser.HostName;
            this.isRegistered = true;
            OnRegistered(new EventArgs());
        }
