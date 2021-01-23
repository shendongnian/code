    public void TriggerEvent()
    {
		var mce = MyCustomEvent;
        if (mce!=null)
		{
            mce(this, new MyEventArgs{ Content = "Geeee! This isn't working!" });
		}
    }
