        public bool isPostBackFromThisControl()
        {
            if (IsPostBack)
            {
                string eventTarget = Request["__EVENTTARGET"];
                Control eventTargetControl = Page.FindControl(eventTarget);
                if (eventTargetControl != null && eventTargetControl.ClientID.StartsWith (this.ClientID))
                    return true;
            }
            return false;
        }
        public bool isPostBackFromOtherControl()
        {
            if (IsPostBack)
            {
                string eventTarget = Request["__EVENTTARGET"];
                Control eventTargetControl = Page.FindControl(eventTarget);
                if (eventTargetControl == null)
                    return true;
                else if (eventTargetControl.ClientID.StartsWith(this.ClientID))
                    return false;
            }
            return false;
        }
