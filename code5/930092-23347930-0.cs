        public static void ShowClientMessageDlg(string msg, string aValue, string redirect = "")
        {
            string msgFormat;
            msgFormat = string.Format(" {0}", aValue);
            msg = msg + msgFormat;
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + msg + "');</script>");
        }
        /// <summary>
        /// Joins a String of Values to create a Message Box
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="aValue"></param>
        /// <param name="redirect"></param>
        public static void ShowClientMessageDlg(string msg, List<string> aValue, string redirect = "")
        {
            string msgFormat;
            msgFormat = string.Format(" {0}", string.Join<string>(", ", aValue.ToArray()));
            msg = msg + msgFormat;
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + msg + "');</script>");
        }
