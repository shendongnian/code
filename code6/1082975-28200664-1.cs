     public class baseForm: Form
     {
        public baseForm()
        {
            this.Load += baseForm_Load;
        }
        void baseForm_Load(object sender, EventArgs e)
        {
          var t = GetAll<TextBoxX>(this);
          foreach (var txtbx in Controls.OfType<TextBox>())
          {
               txtbx.TabStop = (!txtbx.ReadOnly);
          }
         }
        public static List<T> GetAll<T>(Form f1)
	    {
		    List<T> f = new List<T>();
		    try {
			    if (f1 != null) {
				    CheckInner<T>(f1.Controls, ref f);
			    }
		    } catch (Exception ex) {
			    f.Clear();
		    }
		    return f;
        }
	 }
