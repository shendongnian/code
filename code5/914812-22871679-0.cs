        public override string ToString()
        {
          JavaScriptSerializer js = new JavaScriptSerializer(); // Available in   System.Web.Script.Serialization;           
          return js.Serialize(this);
        }
