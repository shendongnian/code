    public struct merge_var
    {
        #region Fields
        /// <summary>
        ///     The content.
        /// </summary>
        public dynamic content;
        /// <summary>
        ///     The name.
        /// </summary>
        public string name;
        #endregion
    }
        public void AddRecipientVariable(string recipient, string name, dynamic content)
        {
            if (this.merge_vars == null)
            {
                this.merge_vars = new List<rcpt_merge_var>();
            }
            rcpt_merge_var entry = this.merge_vars.Where(e => e.rcpt == recipient).FirstOrDefault();
            if (entry == null)
            {
                entry = new rcpt_merge_var { rcpt = recipient };
                this.merge_vars.Add(entry);
            }
            var mv = new merge_var { name = name, content = content };
            entry.vars.Add(mv);
        }
