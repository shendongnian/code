    public void Hit()
    {
            if (this.Session["FirstHit"] != null)
            {
                var lastHit = DateTime.Now.Subtract(DateTime.Parse(this.Session["LastHit"]));
                if (lastHit.Minutes > 5)
                {
                    this.Session["FirstHit"] = null;
                    return;
                }
            }
            else
            {
                this.Session.Add("FirstHit", DateTime.Now);
            }
    Rest of your method ... 
