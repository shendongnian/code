    class CustomBaseUserControl: UserControl{
    int idx1=-1;
	public CustomBaseUserControl()
	{
		Initialize();
		//Fill ComboBox
		
		//Suscribe Event
		combobox1.SelectedIndexChanged += combobox1_SelectedIndexChanged;
	}
	  void combobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = combobox1.SelectedIndex;
            if (index != idx1)
            {
            idx1=index;
            RaiseIndexChanged(e);
            }
        }
		
		    public virtual void RaiseIndexChanged(EventArgs ea)
        {
            var handler = OnIndexChanged;
            if (OnIndexChanged != null)
                OnIndexChanged(this, ea);
        }
		public event EventHandler OnIndexChanged;
    }  
