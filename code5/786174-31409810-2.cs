        // Returns true if postback is from current control, one of child controls of current control or one of parent controls of current controls.
        // Returns false if postback is from any other controls (siblings or parents of the siblings) or if there is no postback.
        public bool IsPostBackFromCurrentControl()
        {
            if (IsPostBack)
            {
                string eventTarget = Request["__EVENTTARGET"];
                if (eventTarget.StartsWith(this.UniqueID))
                    return true;
                else
                    return false;
            }
            return false;
        }
