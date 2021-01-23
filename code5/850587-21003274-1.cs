    class TheFormControl: Form
    {
        CustomBaseUserControl cb;
    	public TheFormControl()
    	{
    		Initialize();
    		cb = new CustomBaseUserControl();
    		cb.OnIndexChanged +=cb_OnIndexChanged;
    	}
    	void cb_OnIndexChanged(object sender, EventArgs e)
        {
    	 // Here you know index has changed on CustomBaseUserControl
        }
    }
