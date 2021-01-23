    public static string GetValueOfControl(WebControl ServerControl)
        {
            string IdOfControl = ServerControl.UniqueID;
            NameValueCollection PostBackFormControls = HttpContext.Current.Request.Form;
            if (PostBackFormControls.AllKeys.Length == 0)
                return null;
            string value = PostBackFormControls[IdOfControl];
            if (value == null)
            {
                int index = 0;
                for (; index < PostBackFormControls.AllKeys.Length; index++)
                    if (PostBackFormControls.AllKeys[index].EndsWith(IdOfControl))
                        break;
                if (index < PostBackFormControls.AllKeys.Length)
                    return PostBackFormControls[index];
                else
                    return null;
            }
            else
            {
                return value;
            }
        }
